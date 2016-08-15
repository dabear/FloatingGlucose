using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FloatingGlucose.Classes
{
    class JSONParsingException: Exception
    {
        public JSONParsingException(string message):base(message)
        {

        }
        public JSONParsingException()
        {

        }
        public JSONParsingException(string message, Exception inner): base(message, inner)
        {

        }

    }
    class PebbleData
    {
        public DateTime date;
        public string lastread;
        public decimal glucose;
        public string delta;
        public string direction;
        public decimal filt;
        public decimal unfilt;
        public decimal noise;
        public decimal slope;
        public decimal intercept;
        public decimal scale;
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
            dynamic data;
            HttpClient client = new HttpClient();
            string urlContents = await client.GetStringAsync(url);

            try
            {
                data = JObject.Parse(urlContents);
                var bgs = data.bgs.First;
                var cals = data.cals.First;

                return new PebbleData
                {
                    date = DateTimeOffset.FromUnixTimeMilliseconds((long)bgs.datetime).DateTime,
                    lastread = (string)bgs.datetime,
                    direction = (string)bgs.direction,
                    glucose = bgs.sgv,
                    delta = bgs.bgdelta,
                    filt = bgs.filtered,
                    unfilt = bgs.unfiltered,
                    noise = bgs.noise,
                    slope = cals.slope,
                    intercept = cals.intercept,
                    scale = cals.scale

                };
            }
            catch (RuntimeBinderException ex) {
                throw new JSONParsingException("Unable to parse json string:" + urlContents, ex);
            }
        }
    }
}
