using FloatingGlucose.Classes;
using FloatingGlucose.Classes.DataSources;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using FloatingGlucose.Classes.DataSources;
using static FloatingGlucose.Properties.Settings;
namespace FloatingGlucose.Classes.DataSources.Plugins 
{
    class NightscoutPebbleEndpoint : IDataSourcePlugin
    {
        public GeneratedNsData NsData;
        public DateTime Date { get; set; }

        public double Glucose { get; set; }
        public double Delta { get; set; }
        public string Direction { get; set; }


        public string FormattedDelta => $"{(this.RoundedDelta() >= 0.0 ? "+" : "")}{this.RoundedDelta():N1}";
        public double RawDelta => this.RawGlucose - this.PreviousRawGlucose;
        public string FormattedRawDelta => $"{(this.RoundedRawDelta() >= 0.0 ? "+" : "")}{this.RoundedRawDelta():N1}";

        public double RoundedDelta() => Math.Round(this.Delta, 1);
        public double RoundedRawDelta() => Math.Round(this.RawDelta, 1);

        public static CultureInfo Culture = new CultureInfo("en-US");
        public double CalculateRawGlucose(Cal cal, Bg bg, double actualGlucose)
        {
            double number;
            double curBG = actualGlucose;
            int specialValue = 0;

            if (this.IsMmol)
            {
                if ((actualGlucose < 2.2) || (actualGlucose > 22.2))
                {
                    specialValue = 1;
                }
                    
                curBG = curBG * 18.01559;
            }
            else
            {
                if ((actualGlucose < 40) || (actualGlucose > 400))
                {
                    specialValue = 1;

                }
                    
            }
            
            //this special value is only triggered when the dexcom upload is brand new
            //from a brand new sensor?
            if (specialValue == 1)
            {
                number = cal.scale * (bg.unfiltered - cal.intercept) / cal.slope;
            } 
            else
            {
                number = cal.scale * (bg.filtered - cal.intercept) / cal.slope / curBG;
                number = cal.scale * (bg.unfiltered - cal.intercept) / cal.slope / number;
            }

            if (this.IsMmol)
            {
                number = number / 18.01559;
            }
                
            
            return number;
        }

        public double PreviousGlucose
        {
            get
            {
                var bgs = this.NsData.bgs.Skip(1).First();
                return Double.Parse(bgs.sgv, NumberStyles.Any, NightscoutPebbleEndpoint.Culture);

            }
        }

        public double PreviousRawGlucose
        {
            get
            {
                try
                {
                    var cal = this.NsData.cals.Skip(1).First();
                    var bg = this.NsData.bgs.Skip(1).First();
                    return this.CalculateRawGlucose(cal, bg, this.PreviousGlucose);
                }
                catch (InvalidOperationException)
                {
                    throw new InvalidJsonDataException("The raw data are not available, enable RAWBG in your azure settings");
                }

            }
        }

        public double RawGlucose
        {
            get
            {
                try
                {

                    var cal = this.NsData.cals.First();
                    var bg = this.NsData.bgs.First();
                    return this.CalculateRawGlucose(cal, bg, this.Glucose);
                }
                catch (InvalidOperationException)
                {
                    throw new InvalidJsonDataException("The raw data are not available, enable RAWBG in your azure settings");
                }

            }
        }

        public DateTime LocalDate => this.Date.ToLocalTime();

        public string DirectionArrow
        {
            get
            {

                switch (this.Direction)
                {
                    case "DoubleUp":
                        return "⇈";
                    case "SingleUp":
                        return "↑";
                    case "FortyFiveUp":
                        return "↗";
                    case "Flat":
                        return "→";
                    case "FortyFiveDown":
                        return "↘";
                    case "SingleDown":
                        return "↓";
                    case "DoubleDown":
                        return "⇊";
                    case "NOT COMPUTABLE":
                        return "-";
                    case "RATE OUT OF RANGE":
                        return "⇕";
                    default:
                    case "None":
                        return "⇼";
                }
            }

        }

        public bool IsMmol => Default.GlucoseUnits == "mmol";
        public string DataSourceName => nameof(NightscoutPebbleEndpoint);
 

        public async Task<IDataSourcePlugin> GetDataSourceDataAsync(string uri)
        //public static async Task<NightscoutPebbleEndpoint> GetNightscoutPebbleDataAsync(string uri)
        {

            var client = new HttpClient();
            
            string urlContents;

            if(Default.AllowFileURIScheme && uri.ToLower().StartsWith("file:///"))
            {
                using (var reader = File.OpenText(new Uri(uri).LocalPath))
                {
                    urlContents = await reader.ReadToEndAsync();
                    
                }
                
            }
            else
            {
                urlContents = await client.GetStringAsync(uri);
            }
            

            Bg bgs = null;

            //urlContents = "{ \"status\":[{\"now\":1471947452808}],\"bgs\":[],\"cals\":[]";
            //urlContents = "{}"
            var parsed =
                this.NsData = JsonConvert.DeserializeObject<GeneratedNsData>(urlContents);
            try
            {

                bgs = parsed.bgs.First();
                this.Direction = bgs.direction;
                this.Glucose = Double.Parse(bgs.sgv, NumberStyles.Any, NightscoutPebbleEndpoint.Culture);
                this.Date = DateTimeOffset.FromUnixTimeMilliseconds(bgs.datetime).DateTime;
                this.Delta = Double.Parse(bgs.bgdelta, NumberStyles.Any, NightscoutPebbleEndpoint.Culture);



            }
            catch (InvalidOperationException ex)
            {
                //this exception might be hit when the nightscout installation is brand new or contains no recent data;
                throw new MissingDataException("No data");

            }

            return this;


        }

       
    }
}