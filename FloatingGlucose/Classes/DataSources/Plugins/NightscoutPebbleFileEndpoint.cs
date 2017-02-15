using FloatingGlucose.Classes.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FloatingGlucose.Classes.DataSources.Plugins
{
    internal class NightscoutPebbleFileEndpoint : NightscoutPebbleEndpoint, IDataSourcePlugin
    {
        public override bool RequiresBrowseButton => true;
        public override string BrowseDialogFileFilter => "Nightscout Dumps|*.nsdata.dump;*.nsdata|Text files|*.txt";
        public override string DataSourceShortName => "Nightscout File Dump";
        public override int SortOrder => 11;

        public override void OnPluginSelected(FormGlucoseSettings form)
        {
            form.lblDataSourceLocation.Text = "Your File Dump location";
        }

        public override bool VerifyConfig(Properties.Settings settings)
        {
            if (!Validators.IsReadableFile(settings.DataPathLocation))
            {
                throw new ConfigValidationException("You have entered an invalid file path for the data dump!");
            }

            return true;
        }

        public override async Task<IDataSourcePlugin> GetDataSourceDataAsync(NameValueCollection locations)
        {
            var datapath = locations["raw"];
            var client = new HttpClient();
            string fileContents;

            // datapath is expected to be a valid file
            // Exceptions will be handled by the main program
            using (var reader = File.OpenText(datapath))
            {
                fileContents = await reader.ReadToEndAsync();
            }

            Bg bgs = null;
            var parsed =
                this.NsData = JsonConvert.DeserializeObject<GeneratedNsData>(fileContents);

            bgs = parsed.bgs.First();
            this.Direction = bgs.direction;
            this.Glucose = Double.Parse(bgs.sgv, NumberStyles.Any, CultureInfo.InvariantCulture);
            this.Date = DateTimeOffset.FromUnixTimeMilliseconds(bgs.datetime).DateTime;
            this.Delta = Double.Parse(bgs.bgdelta, NumberStyles.Any, CultureInfo.InvariantCulture);

            return this;
        }
    }
}