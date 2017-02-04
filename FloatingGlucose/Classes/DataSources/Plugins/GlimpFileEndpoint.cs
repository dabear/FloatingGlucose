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

        public DateTime Date
        {
            get
            {
                var firstCsv = this.csv.First();

                return DateTime.ParseExact(firstCsv.DateReading, "dd/MM/yyyy HH.mm.ss", CultureInfo.InvariantCulture);


                //for testing only:
                //return new DateTime(1988, 06, 05);
            }
        }

        



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

        public bool IsMmol => Default.GlucoseUnits == "mmol";

        private double ConvertToMmolIfNeeded(double glucose)
        {

            if (this.IsMmol)
            {
                
                return glucose / 18.01559;
            }
            return glucose;
        }


        public double Glucose
        {
            get
            {
                var reading = this.csv.First();
                return ConvertToMmolIfNeeded(Double.Parse(reading.Glucose, NumberStyles.Any, NightscoutPebbleFileEndpoint.Culture));

            }
        }

        public double PreviousGlucose
        {
            get
            {
                var reading = this.csv.Skip(1).First();
                return ConvertToMmolIfNeeded(Double.Parse(reading.Glucose, NumberStyles.Any, NightscoutPebbleFileEndpoint.Culture));
            }
        }

        public string Direction
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

            



            return this;


        }


        
    }
}