using FloatingGlucose.Classes;
using FloatingGlucose.Classes.DataSources;
using FloatingGlucose.Classes.DataSources.Plugins;
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
using System.Windows.Forms;
using static FloatingGlucose.Properties.Settings;
namespace FloatingGlucose.Classes.DataSources
{
    public interface IDataSourcePlugin
    {

        DateTime Date { get; }

        double Glucose { get; }
        double PreviousGlucose { get; }
        double Delta { get; }
        double RawDelta { get; }
        //this is a text describing in which direction the current glucose trend is heading
        string Direction { get; }
        double RawGlucose { get; }
        double PreviousRawGlucose { get; }
        
        double RoundedDelta();
        double RoundedRawDelta();

        DateTime LocalDate { get; }

        string DataSourceShortName { get; }

        Task<IDataSourcePlugin>  GetDataSourceDataAsync(NameValueCollection datapath);

        bool VerifyConfig(Properties.Settings settings);

        //GUI related
        void OnPluginSelected(FormGlucoseSettings settingsForm);
        bool RequiresBrowseButton { get; }
        string BrowseDialogFileFilter { get; }

    }
    
}