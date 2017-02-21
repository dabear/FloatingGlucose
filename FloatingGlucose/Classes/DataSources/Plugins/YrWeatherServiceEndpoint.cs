using FloatingGlucose.Classes.Extensions;
using FloatingGlucose.Classes.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static FloatingGlucose.Properties.Settings;
using System.Windows.Forms;

namespace FloatingGlucose.Classes.DataSources.Plugins
{
    internal class YrWeatherServiceEndpoint : IDataSourcePlugin
    {
        public bool PluginDisabled => !AppShared.isDebuggingBuild;
        public bool RequiresBrowseButton => false;
        public string BrowseDialogFileFilter => "";
        public string DataSourceShortName => "Yr.no Weather";
        public virtual int SortOrder => 20;

        public DateTime Date => new DateTime(1970, 1, 1);

        public double Delta => this.Glucose - this.PreviousGlucose;

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

        private string getYrForeCastURL(string pathname) => String.Format(this.yrForeCast, pathname);

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

        private bool VerifyYrPathString(string path)
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
        }

        public bool VerifyConfig(Properties.Settings settings)
        {
            var pathname = settings.DataPathLocation;
            settings.DataPathLocation = pathname;
            if (this.VerifyYrPathString(pathname))
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

            if (!this.VerifyYrPathString(settings.DataPathLocation))
            {
                throw new ConfigValidationException("The entered weather location was not correctly formed!");
            }

            return true;
        }

        public async Task<IDataSourcePlugin> GetDataSourceDataAsync(NameValueCollection locations)
        {
            var pathname = locations["raw"];
            var forecast = this.getYrForeCastURL(pathname);
            return this;
        }
    }
}