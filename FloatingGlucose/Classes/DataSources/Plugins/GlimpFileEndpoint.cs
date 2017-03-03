using FloatingGlucose.Classes.Extensions;
using FloatingGlucose.Classes.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using static FloatingGlucose.Properties.Settings;

namespace FloatingGlucose.Classes.DataSources.Plugins
{
    internal class RawGlimpData : BgReading
    {
        public string FileVersion;
        public string RawGlucose;
        public string SensorId;
    }

    internal class GlimpFileEndpoint : IDataSourcePlugin
    {
        public bool PluginDisabled => false;
        public bool RequiresUserNameAndPassword => false;
        public bool RequiresDataSource => true;

        public List<string> HandleFormatting() => null;

        public bool RequiresBrowseButton => true;
        public bool PluginHandlesFormatting => false;
        public string BrowseDialogFileFilter => "Glimp Glucose file |GlicemiaMisurazioni.csv";
        public string DataSourceShortName => "Glimp Dropbox File";
        public virtual int SortOrder => 20;

        private List<RawGlimpData> csv = new List<RawGlimpData>();

        public DateTime Date => this.csv.First().DateReading;

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

        public double Glucose => this.UserWantsMmolUnits() ? this.csv.First().GlucoseMmol : this.csv.First().GlucoseMgdl;

        private DateTime GlimpDateStringToDateTime(string reading) => DateTime.ParseExact(reading, "dd/MM/yyyy HH.mm.ss", CultureInfo.InvariantCulture);

        public double PreviousGlucose
        {
            get
            {
                RawGlimpData reading;

                try
                {
                    reading = this.csv.Skip(1).First();
                }
                catch (InvalidOperationException)
                {
                    //this is factually incorrect, but will provide a delta of 0 in the GUI,
                    //which is what we want
                    //reading the first entry might also fail, but we presume the file has content when it's created
                    reading = this.csv.First();
                }

                return this.UserWantsMmolUnits() ? reading.GlucoseMmol : reading.GlucoseMgdl;
            }
        }

        public string Direction
        {
            get
            {
                //Sligthly more advanced implementation of direction
                //Calculates a slope per minute
                //(how much glucose has changed every minute between two readings)

                var first = this.csv.First();
                RawGlimpData last;
                try
                {
                    last = this.csv.Skip(1).First();
                }
                catch (InvalidOperationException)
                {
                    last = first;
                }

                var dir = first.GetRelativeGlucoseDirection(last);
                Debug.WriteLine($"glimpfile got glucose direction:{dir}");
                return dir;
            }
        }

        public void OnPluginSelected(FormGlucoseSettings form)
        {
            form.lblDataSourceLocation.Text = "Your File Dump location";
            var source = form.txtDataSourceLocation.Text.ToLower();
            //for this plugin, we don't handle http:// and https://
            //if the source does not resemble an url, it should clearly be removed.
            if (source.StartsWith("http://") || source.StartsWith("https://"))
            {
                form.txtDataSourceLocation.Text = "";
            }
        }

        public bool VerifyConfig(Properties.Settings settings)
        {
            if (!Validators.IsReadableFile(settings.DataPathLocation))
            {
                throw new ConfigValidationException("You have entered an invalid file path for the data dump!");
            }

            return true;
        }

        public async Task<IDataSourcePlugin> GetDataSourceDataAsync(NameValueCollection locations)
        {
            var datapath = locations["raw"];
            var client = new HttpClient();

            this.csv.Clear();
            // datapath is expected to be a valid file
            // Exceptions will be handled by the main program
            using (var reader = new StreamReader(datapath, System.Text.Encoding.Unicode))
            {
                int i = 0;

                while (true)
                {
                    //something wrong here, it is read wrongly..
                    string line = await reader.ReadLineAsync();
                    if (line == null || i++ > 100)
                    {
                        break;
                    }
                    if (line.Trim().Length == 0)
                    {
                        continue;
                    }
                    string[] items = line.Split(';');
                    var data = new RawGlimpData();

                    //Measurement type (0=manual measurement, 1=Freestyle Libre)
                    //if (items[6] == "1")
                    //{
                    data.FileVersion = items[0];
                    data.DateReading = GlimpDateStringToDateTime(items[1]);
                    data.RawGlucose = items[4];
                    data._glucose = Double.Parse(items[5], NumberStyles.Any, CultureInfo.InvariantCulture);
                    data.SensorId = items[7];
                    //}

                    this.csv.Add(data);
                }
            }

            return this;
        }
    }
}