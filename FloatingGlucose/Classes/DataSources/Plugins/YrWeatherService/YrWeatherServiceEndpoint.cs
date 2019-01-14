using FloatingGlucose.Classes.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xml2CSharp;

namespace FloatingGlucose.Classes.DataSources.Plugins
{
    internal class YrWeatherServiceEndpoint : IDataSourcePlugin
    {
        public string Acknowledgment => "Weather forecast from Yr, delivered by the Norwegian Meteorological Institute and the NRK";

        public string AcknowledgmentUrl => "";
        public string Author => "Bjørn inge Vikhammermo";

        public bool PluginHandlesFormatting => true;
        public bool RequiresUserNameAndPassword => false;
        public bool RequiresDataSource => true;
        public bool PluginDisabled => true;
        public bool RequiresBrowseButton => false;
        public string BrowseDialogFileFilter => "";
        public string DataSourceShortName => "Yr.no Weather";
        public virtual int SortOrder => 20;

        public DateTime Date
        {
            get
            {
                var from = this.weatherData?.Forecast?.Tabular?.Time[0]?.From;
                return from == null || from.Length == 0 ? DateTime.MinValue : DateTime.Parse(from);
            }
        }

        public double Delta => this.Glucose - this.PreviousGlucose;

        //glucose,lastupdate,delta,notification
        public List<string> HandleFormatting()
        {
            var texts = new List<string>();

            if (this.weatherData != null)
            {
                var temp = this.weatherData.Forecast?.Tabular?.Time?[0]?.Temperature;
                var val = temp?.Value ?? "";
                var unit = temp.Unit?[0].ToString()?.ToUpper() ?? "";
                var temperature = $"{val} °{unit}";
                texts.Add(temperature);
                texts.Add(this.Date.ToLocalTime().ToShortTimeString());
                texts.Add(this.weatherData.Location?.Name ?? "");

                texts.Add("Weatherdata plugin active");

                return texts;
            }
            texts.Add("Error");
            texts.Add("Cannot");
            texts.Add("get weatherdata");
            texts.Add("error");

            return texts;
        }

        //
        // Raw glucose is not supported for this plugin
        //
        public double RawDelta => 0.0;

        public double RoundedRawDelta() => 0.0;

        public double RawGlucose => 0.0;
        public double PreviousRawGlucose => 0.0;

        public DateTime LocalDate => this.Date;

        public double RoundedDelta() => Math.Round(this.Delta, 1);

        public double Glucose => 0.0;

        public double PreviousGlucose => 0.0;

        public string Direction => "Flat";

        private string yrSearchUrl = "https://www.yr.no/soek/soek.aspx?&land=&spr=eng&region1=&sok=Search&sted=";
        private string yrForeCast = "http://www.yr.no/{0}/forecast_hour_by_hour.xml";

        private Weatherdata weatherData;

        private string getYrForeCastURL(string pathname) => String.Format(this.yrForeCast, pathname);

        //override specific for this plugin as it doesn't really handle deltas

        public FormWebbrowser createYrSearchBrowser(string city)
        {
            var js = @"

(function(){
    if (!String.prototype.startsWith) {
        String.prototype.startsWith = function(searchString, position){
          position = position || 0;
          return this.substr(position, searchString.length) === searchString;
        };
    }

    function handler(ev) {
        var event  = window.event || event;
        var target = event.srcElement || event.target;

        if( target.tagName != 'A') {
           return false;
        }

        var pathname = target.pathname;
        if(pathname.substring(0, 1) != '/') {
          pathname = '/'+ pathname;
        }
        //alert('will now try to close, pathname: ' + pathname);
        if(pathname.startsWith('/place/') ||
           pathname.startsWith('/sted/') ||
           pathname.startsWith('/stad/') ||
           pathname.startsWith('/sadji/')
        ) {
            //alert('will now close with reval:' + pathname)
            //console.log('set return value and close:' + pathname);
            window.external.SetReturnValueAndClose(pathname);
        }

        ev.preventDefault && ev.preventDefault();

        return false;
    }
    var aEL=window.addEventListener;
    alert('Please choose the most appropriate location in the following web page')

    document.body[ aEL ? 'addEventListener' : 'attachEvent' ]( aEL ? 'click' : 'onclick', handler )
})();
";
            var form = new FormWebbrowser(js);
            form.SetBrowserUrl(this.yrSearchUrl + city);
            form.ShowDialog();
            return form;
        }

        private Weatherdata deserializeWeatherData(string xmlsource)
        {
            Weatherdata weather;

            using (var reader = new StringReader(xmlsource))
            {
                var serializer = new XmlSerializer(typeof(Weatherdata));
                weather = (Weatherdata)serializer.Deserialize(reader);

                return weather;
            }
        }

        private bool verifyYrPathString(string path)
        {
            if (path.StartsWith("/place/") || path.StartsWith("/sted/") ||
               path.StartsWith("/stad/") ||
               path.StartsWith("/sadji/"))
            {
                return path.Count(x => x == '/') > 4;
            }

            return false;
        }

        public void OnPluginSelected(FormGlucoseSettings form)
        {
            form.lblDataSourceLocation.Text = "Your closest location";

            var source = form.txtDataSourceLocation.Text.ToLower();
            //for this plugin, we handle only city names and yr.no path names
            //if the source resembles an url, it should clearly be removed.
            if (source.StartsWith("http://") || source.StartsWith("https://"))
            {
                form.txtDataSourceLocation.Text = "";
            }
        }

        public bool VerifyConfig(Properties.Settings settings)
        {
            var pathname = settings.DataPathLocation;
            settings.DataPathLocation = pathname;
            if (this.verifyYrPathString(pathname))
            {
                return true;
            }
            //
            // pathname entered by user is most probably in the form of "Stockholm"
            // We need the a more specific path "/place/Sweden/Stockholm/Stockholm"
            //

            var client = this.createYrSearchBrowser(pathname);

            settings.DataPathLocation = client.WebPageReturnValue;

            var url = this.getYrForeCastURL(settings.DataPathLocation);

            if (!this.verifyYrPathString(settings.DataPathLocation))
            {
                throw new ConfigValidationException("The entered weather location was not correctly formed!");
            }

            return true;
        }

        public async Task<IDataSourcePlugin> GetDataSourceDataAsync(NameValueCollection locations)
        {
            this.WriteDebug("Will now try refresh using YR.no");
            var pathname = locations["raw"];
            var forecastUrl = this.getYrForeCastURL(pathname);

            try
            {
                var client = new HttpClient();
                string urlContents = await client.GetStringAsync(forecastUrl);

                this.weatherData = this.deserializeWeatherData(urlContents);
            }
            catch (Exception err)
            {
                this.WriteDebug($"got error in fetching xmldata from {forecastUrl}: {err.Message}");
                throw (err);
            }

            return this;
        }
    }
}