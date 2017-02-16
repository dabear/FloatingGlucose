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

        private string yrSearchUrl = "https://www.yr.no/soek/soek.aspx?&land=&region1=&sok=Search&sted=";

        public void OnPluginSelected(FormGlucoseSettings form)
        {
            form.lblDataSourceLocation.Text = "Your closest location";
        }

        public bool VerifyConfig(Properties.Settings settings)
        {
            var city = WebUtility.UrlEncode(settings.DataPathLocation);

            var client = new HttpClient();

            var urlContents = WebUtility.HtmlDecode(client.GetStringAsync($"{yrSearchUrl}").Result);

            // var doc = new System.net.http.ht();

            return true;
        }

        public async Task<IDataSourcePlugin> GetDataSourceDataAsync(NameValueCollection locations)
        {
            var datapath = locations["raw"];

            return this;
        }
    }
}