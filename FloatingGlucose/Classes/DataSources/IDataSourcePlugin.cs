using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatingGlucose.Classes.DataSources
{
    public interface IDataSourcePlugin
    {
        bool RequiresUserNameAndPassword { get; }
        bool RequiresDataSource { get; }
        int SortOrder { get; }
        bool PluginHandlesFormatting { get; }

        List<string> HandleFormatting();

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

        Task<IDataSourcePlugin> GetDataSourceDataAsync(NameValueCollection datapath);

        bool VerifyConfig(Properties.Settings settings);

        //GUI related
        void OnPluginSelected(FormGlucoseSettings settingsForm);

        bool RequiresBrowseButton { get; }
        string BrowseDialogFileFilter { get; }
        bool PluginDisabled { get; }
    }
}