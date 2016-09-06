using FloatingGlucose.Classes;
using FloatingGlucose.Classes.Pebble;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using static FloatingGlucose.Properties.Settings;
namespace FloatingGlucose.Classes.Pebble
{
    class PebbleData
    {
        public GeneratedNsData NsData;
        public DateTime Date;

        public double Glucose;
        public double Delta = 0.0;
        public string Direction;

        public static bool IsMmol => Default.GlucoseUnits == "mmol";
        public string FormattedDelta => $"{(this.RoundedDelta() >= 0.0 ? "+" : "")}{this.RoundedDelta():N1}";
        public double RawDelta => this.RawGlucose - this.PreviousRawGlucose;
        public string FormattedRawDelta => $"{(this.RoundedRawDelta() >= 0.0 ? "+" : "")}{this.RoundedRawDelta():N1}";

        public double RoundedDelta() => Math.Round(this.Delta, 1);
        public double RoundedRawDelta() => Math.Round(this.RawDelta, 1);

        public static CultureInfo Culture = new CultureInfo("en-US");
        public static double CalculateRawGlucose(Cal cal, Bg bg, double actualGlucose)
        {
            double number;
            double curBG = actualGlucose;
            int specialValue = 0;

            if (IsMmol)
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

            if (IsMmol)
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
                return Double.Parse(bgs.sgv, NumberStyles.Any, PebbleData.Culture);

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
                    return PebbleData.CalculateRawGlucose(cal, bg, this.PreviousGlucose);
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
                    return PebbleData.CalculateRawGlucose(cal, bg, this.Glucose);
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


        public static async Task<PebbleData> GetNightscoutPebbleDataAsync(string url)
        {

            var client = new HttpClient();
            var pebbleData = new PebbleData();
            string urlContents = await client.GetStringAsync(url);

            Bg bgs = null;

            //urlContents = "{ \"status\":[{\"now\":1471947452808}],\"bgs\":[],\"cals\":[]";
            //urlContents = "{}"
            var parsed =
                pebbleData.NsData = JsonConvert.DeserializeObject<GeneratedNsData>(urlContents);
            try
            {

                bgs = parsed.bgs.First();
                pebbleData.Direction = bgs.direction;
                pebbleData.Glucose = Double.Parse(bgs.sgv, NumberStyles.Any, PebbleData.Culture);
                pebbleData.Date = DateTimeOffset.FromUnixTimeMilliseconds(bgs.datetime).DateTime;
                pebbleData.Delta = Double.Parse(bgs.bgdelta, NumberStyles.Any, PebbleData.Culture);



            }
            catch (InvalidOperationException ex)
            {
                //this exception might be hit when the nightscout installation is brand new or contains no recent data;
                throw new MissingDataException("No data");

            }

            return pebbleData;


        }
    }
}