using FloatingGlucose.Classes.Extensions;
using FloatingGlucose.Classes.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using static FloatingGlucose.Properties.Settings;
using ShareClientDotNet;

namespace FloatingGlucose.Classes.DataSources.Plugins
{
    internal class DexcomShareEndpoint : IDataSourcePlugin
    {
        public bool PluginDisabled => false;
        public bool RequiresUserNameAndPassword => true;
        public bool RequiresDataSource => false;

        public List<string> HandleFormatting() => null;

        public bool RequiresBrowseButton => false;
        public bool PluginHandlesFormatting => false;
        public string BrowseDialogFileFilter => "";
        public string DataSourceShortName => "Dexcom Share (US)";
        public virtual int SortOrder => 25;

        //private List<RawGlimpData> csv = new List<RawGlimpData>();

        public DateTime Date => DateTime.Now;

        public double Delta => this.Glucose - this.PreviousGlucose;

        //
        // Raw glucose is not supported for this plugin
        //
        public double RawDelta => 0.0;

        public double RoundedRawDelta() => 0.0;

        public double RawGlucose => 0.0;
        public double PreviousRawGlucose => 0.0;

        public DateTime LocalDate => this.Date;

        public double RoundedDelta() => Math.Round(this.Delta, 1);

        public double Glucose => this.UserWantsMmolUnits() ? 0 : 1;

        protected ShareClient shareClient = new ShareClient();

        public double PreviousGlucose
        {
            get
            {
                //return this.UserWantsMmolUnits() ? reading.GlucoseMmol : reading.GlucoseMgdl;
                return 0;
            }
        }

        public string Direction
        {
            get
            {
                //Sligthly more advanced implementation of direction
                return "";
            }
        }

        public void OnPluginSelected(FormGlucoseSettings form)
        {
            form.lblDataSourceLocation.Text = "Dexcom share server";
            form.txtDataSourceLocation.Text = this.shareClient.CurrentDexcomServer;
        }

        public bool VerifyConfig(Properties.Settings settings)
        {
            var username = settings.UserName;
            var password = settings.HashedPassword?.Text ?? "";

            if (username.Length < 2)
            {
                throw new ConfigValidationException("UserName field was not correctly filled!");
            }

            if (password.Length < 1)
            {
                throw new ConfigValidationException("Password field was not correctly filled!");
            }

            /*if (!Validators.IsReadableFile(settings.DataPathLocation))
            {
                throw new ConfigValidationException("You have entered an invalid file path for the data dump!");
            }*/

            return true;
        }

        public async Task<IDataSourcePlugin> GetDataSourceDataAsync(NameValueCollection locations)
        {
            var datapath = locations["raw"];

            return this;
        }
    }
}