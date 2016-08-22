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

namespace FloatingGlucose.Classes
{
    class InvalidJSONDataException : Exception
    {
        public InvalidJSONDataException(string message) : base(message)
        {

        }
        public InvalidJSONDataException()
        {

        }
        
        public InvalidJSONDataException(string message, Exception inner) : base(message, inner)
        {

        }

    }

    class MissingDataException : Exception
    {
        public MissingDataException(string message) : base(message)
        {

        }
        public MissingDataException()
        {

        }

        public MissingDataException(string message, Exception inner) : base(message, inner)
        {

        }

    }



    class PebbleData
    {
        public Generated_NSDATA nsdata;
        public DateTime date;
        
        public double glucose;
        public double delta = 0.0;
        public string direction;


        public string formattedDelta => $"{(this.delta >= 0.0 ? "+" : "")}{this.delta:N1}";
        public double rawDelta => this.rawGlucose - this.previousRawGlucose;
        public string formattedRawDelta => $"{(this.rawDelta >= 0.0 ? "+" : "")}{this.rawDelta:N1}";

        public static CultureInfo culture = new CultureInfo("en-US");
        public static double CalculateRawGlucose(Cal cal, Bg bg, double actualGlucose) {
            double number;
            number = (cal.scale * (bg.filtered - cal.intercept) / cal.slope / actualGlucose);
            number = (cal.scale * (bg.unfiltered - cal.intercept) / cal.slope / number);

            return number;
        }

        public double previousGlucose 
        {
            get
            {
                var bgs = this.nsdata.bgs.Skip(1).First();
                return Double.Parse(bgs.sgv, NumberStyles.Any, PebbleData.culture);

            }
        }

        public double previousRawGlucose
        {
            get
            {
                try
                {
                    var cal = this.nsdata.cals.Skip(1).First();
                    var bg = this.nsdata.bgs.Skip(1).First();
                    return PebbleData.CalculateRawGlucose(cal, bg, this.previousGlucose);
                }
                catch (InvalidOperationException)
                {
                    throw new InvalidJSONDataException("The raw data are not available, enable RAWBG in your azure settings");
                }

            }
        }

        public double rawGlucose {
            get {
                try
                {

                    var cal = this.nsdata.cals.First();
                    var bg = this.nsdata.bgs.First();
                    return PebbleData.CalculateRawGlucose(cal, bg, this.glucose);
                }
                catch(InvalidOperationException)
                {
                    throw new InvalidJSONDataException("The raw data are not available, enable RAWBG in your azure settings");
                }
                
            }
        }

        public DateTime localDate => this.date.ToLocalTime();
 
        public string directionArrow
        {
            get
            {

                switch (this.direction)
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

            HttpClient client = new HttpClient();       
            var pebbleData = new PebbleData();
            string urlContents = await client.GetStringAsync(url);

            Bg bgs = null;

            var parsed =
            pebbleData.nsdata = JsonConvert.DeserializeObject<Generated_NSDATA>(urlContents);
            try
            {
                
                bgs = parsed.bgs.First();
                pebbleData.direction = bgs.direction;
                pebbleData.glucose = Double.Parse(bgs.sgv, NumberStyles.Any, PebbleData.culture);
                pebbleData.date = DateTimeOffset.FromUnixTimeMilliseconds(bgs.datetime).DateTime;
                pebbleData.delta = Double.Parse(bgs.bgdelta, NumberStyles.Any, PebbleData.culture);
                 
                

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
