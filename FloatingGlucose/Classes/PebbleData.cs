using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FloatingIcon.Classes
{
    class PebbleData
    {
        public DateTime date;
        public string glucose;
        public string direction;
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
            string urlContents = await client.GetStringAsync(url);
            dynamic data = JObject.Parse(urlContents);
            var bgs = data.bgs.First;

            return new PebbleData
            {
                date = DateTimeOffset.FromUnixTimeMilliseconds((long)bgs.datetime).DateTime,
                direction = (string)bgs.direction,
                glucose = bgs.sgv

            };

        }

    }
}
