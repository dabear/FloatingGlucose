using FloatingGlucose.Classes;
using FloatingGlucose.Classes.DataSources;
using FloatingGlucose.Classes.DataSources.Plugins;
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
namespace FloatingGlucose.Classes.DataSources
{
    interface IDataSourcePlugin
    {

        DateTime Date { get; }

        double Glucose { get; }
        double PreviousGlucose { get; }
        double Delta { get; }
        double RawDelta { get; }
        //this is a text describing in which direction the current glucose trend is heading
        string Direction { get; }
        string DirectionArrow { get; }
        double RawGlucose { get; }
        double PreviousRawGlucose { get; }
        
        string FormattedDelta { get; }

        string FormattedRawDelta { get; }

        double RoundedDelta();
        double RoundedRawDelta();

        DateTime LocalDate { get; }


        Task<IDataSourcePlugin> GetDataSourceDataAsync(string uri);
    }
    
}