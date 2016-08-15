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
    class MissingJSONDataException : Exception
    {
        public MissingJSONDataException(string message) : base(message)
        {

        }
        public MissingJSONDataException()
        {

        }
        public MissingJSONDataException(string message, Exception inner) : base(message, inner)
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


        public string formattedDelta
        {
            get {

                if (this.delta >= 0.0)
                {
                    return String.Format("+{0:N1}", this.delta);
                }

                return String.Format("-{0:N1}", this.delta);
            }
        }
        

        public double rawGlucose {
            get {
                try
                {
                    double number;
                    Cal cals = this.nsdata.cals.First();
                    Bg bgs = this.nsdata.bgs.First();

                    number = (cals.scale * (bgs.filtered - cals.intercept) / cals.slope / this.glucose);
                    number = (cals.scale * (bgs.unfiltered - cals.intercept) / cals.slope / number);
                    return Math.Round(number, 1);
                }
                catch(InvalidOperationException)
                {
                    throw new MissingJSONDataException("The raw data are not available, enable RAWBG in your azure settings");
                }
                
            }
        }

        public DateTime localDate
        {
            get {
                return this.date.ToLocalTime();
            }
        }
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
            var culture = new CultureInfo("en-US");
            var pebbleData = new PebbleData();

            string urlContents = await client.GetStringAsync(url);
            var parsed = JsonConvert.DeserializeObject<Generated_NSDATA>(urlContents);

            
            pebbleData.nsdata = parsed;

            try
            {
                
                Bg bgs = parsed.bgs.First();

                pebbleData.direction = bgs.direction;
                pebbleData.glucose = Double.Parse(bgs.sgv, NumberStyles.Any, culture);
                pebbleData.date = DateTimeOffset.FromUnixTimeMilliseconds(bgs.datetime).DateTime;
                pebbleData.delta = Double.Parse(bgs.bgdelta, NumberStyles.Any, culture);
                 
                

            }
            catch (Exception)
            {
                return null;
            }

            return pebbleData;
            

        }
    }
}
