using FloatingGlucose.Classes;
using FloatingGlucose.Classes.DataSources;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


using static FloatingGlucose.Properties.Settings;
namespace FloatingGlucose.Classes.DataSources.Plugins 
{
    struct RawGlimpData
    {
        public string FileVersion;
        public string DateReading;
        public string RawGlucose;
        public string Glucose;
        public string SensorId;
     
    }

    class GlimpFileEndpoint : IDataSourcePlugin
    {
        public bool RequiresBrowseButton => true;
        public string BrowseDialogFileFilter => "Glimp Glucose file |GlicemiaMisurazioni.csv";
        public string DataSourceShortName => "Glimp Dropbox File";

        private List<RawGlimpData> csv = new List<RawGlimpData>();

        public string Direction;
        public double Glucose;
        public double PreviousGlucose;

        public DateTime Date
        {
            get
            {
                var firstCsv = this.csv.First();
                // if(firstCsv)
                // {
                // return Convert.ToDateTime(firstCsv.DateReading);
                return DateTime.ParseExact(firstCsv.DateReading, "dd/MM/yyyy HH.mm.ss", CultureInfo.InvariantCulture);
                // }

                return new DateTime(1988, 06, 05);
            }
        }

        

        

        public double Delta
        {
            get
            {
                return 0.0;
            }
        }

        public double RawDelta
        {
            get
            {
                return 0.0;
            }
        }


        public double RawGlucose
        {
            get
            {
                return 0.0;
            }
        }

        public double PreviousRawGlucose
        {
            get
            {
                return 0.0;
            }
        }

        public string FormattedDelta
        {
            get
            {
                return "";
            }
        }

        public string FormattedRawDelta
        {
            get
            {
                return "";
            }
        }

        public DateTime LocalDate
        {
            get
            {
                return this.Date;
            }
        }

        double IDataSourcePlugin.Glucose
        {
            get
            {
                var reading = this.csv.First();
                //if (reading != null)
                //{
                    return Double.Parse(reading.Glucose, NumberStyles.Any, NightscoutPebbleFileEndpoint.Culture);
               // }

            }
        }

        double IDataSourcePlugin.PreviousGlucose
        {
            get
            {
                var reading = this.csv.Skip(1).First();
                return Double.Parse(reading.Glucose, NumberStyles.Any, NightscoutPebbleFileEndpoint.Culture);
            }
        }

        string IDataSourcePlugin.Direction
        {
            get
            {
                return "n/a";
            }
        }

        public string DirectionArrow
        {
            get
            {
                return "n/a";
            }
        }

        public void OnPluginSelected(FormGlucoseSettings form)
        {
            form.lblDataSourceLocation.Text = "Your File Dump location";
        }
        public bool VerifyConfig(Properties.Settings settings)
        {
            if (!Validators.IsReadableFile(settings.DataPathLocation))
            {
                throw new ConfigValidationError("You have entered an invalid file path for the data dump!");

            }

            return true;
        }

        public async Task<IDataSourcePlugin> GetDataSourceDataAsync(NameValueCollection locations)
        {
            var datapath = locations["raw"];
            var client = new HttpClient();
            

            // datapath is expected to be a valid file
            // Exceptions will be handled by the main program
            using (var reader = new StreamReader(datapath, System.Text.Encoding.Unicode))
            {
                int i = 0;
                while (true)
                {

                    //something wrong here, it is read wrongly..
                    string line = await reader.ReadLineAsync();
                    if (line == null || i++ > 100) {
                        break;
                    }
                    if(line.Trim().Length == 0)
                    {
                        continue;
                    }
                    string[] items = line.Split(';');
                    var data = new RawGlimpData();

                    //Measurement type (0=manual measurement, 1=Freestyle Libre)
                    //if (items[6] == "1")
                    //{
                        data.FileVersion = items[0];
                        data.DateReading = items[1];
                        data.RawGlucose = items[4];
                        data.Glucose = items[5];
                        data.SensorId = items[7];
                    //}


                    this.csv.Add(data);
                }

            }

            if(this.csv.Count() > 0)
            {
                this.Direction = "";
                
                //this.Date = DateTimeOffset.FromUnixTimeMilliseconds(bgs.datetime).DateTime;
                //this.Delta = Double.Parse(bgs.bgdelta, NumberStyles.Any, NightscoutPebbleFileEndpoint.Culture);
            }



            return this;


        }

        public double RoundedDelta()
        {
            return 0.0;
        }

        public double RoundedRawDelta()
        {
            return 0.0;
        }
    }
}