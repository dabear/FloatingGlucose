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


using static FloatingGlucose.Properties.Settings;
namespace FloatingGlucose.Classes.DataSources.Plugins 
{
    class NightscoutPebbleFileEndpoint : NightscoutPebbleEndpoint, IDataSourcePlugin
    {
       

        public override async Task<IDataSourcePlugin> GetDataSourceDataAsync(string datapath)
        {

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
            this.Glucose = Double.Parse(bgs.sgv, NumberStyles.Any, NightscoutPebbleFileEndpoint.Culture);
            this.Date = DateTimeOffset.FromUnixTimeMilliseconds(bgs.datetime).DateTime;
            this.Delta = Double.Parse(bgs.bgdelta, NumberStyles.Any, NightscoutPebbleFileEndpoint.Culture);



           

            return this;


        }

       
    }
}