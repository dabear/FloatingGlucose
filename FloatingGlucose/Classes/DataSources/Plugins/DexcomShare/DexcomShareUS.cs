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
using System.Windows.Forms;

namespace FloatingGlucose.Classes.DataSources.Plugins
{
    internal class DexcomShareEndpoint : IDataSourcePlugin
    {
        public string Acknowledgment => "Dexcom share plugin by Bjørn inge Vikhammermo";

        public string AcknowledgmentUrl => "";
        public string Author => "Bjørn inge Vikhammermo";

        public bool PluginDisabled => false;
        public bool RequiresUserNameAndPassword => true;
        public bool RequiresDataSource => false;

        public List<string> HandleFormatting() => null;

        public bool RequiresBrowseButton => false;
        public bool PluginHandlesFormatting => false;
        public string BrowseDialogFileFilter => "";
        public virtual string DataSourceShortName => "Dexcom Share (US)";
        public virtual int SortOrder => 25;

        //private List<RawGlimpData> csv = new List<RawGlimpData>();

        public DateTime Date
        {
            get
            {
                var reading = this.shareGlucose.First();
                return reading.LocalTime;
            }
        }

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

        public double Glucose
        {
            get
            {
                var reading = this.shareGlucose.First();

                return Convert.ToDouble(this.UserWantsMmolUnits() ? reading.ValueMmol : reading.ValueMgdl);
            }
        }

        protected ShareClient shareClient = new ShareClient();

        protected List<ShareGlucose> shareGlucose = new List<ShareGlucose>();

        public double PreviousGlucose
        {
            get
            {
                var reading = this.shareGlucose.Skip(1).First();

                return Convert.ToDouble(this.UserWantsMmolUnits() ? reading.ValueMmol : reading.ValueMgdl);
            }
        }

        public string Direction
        {
            get
            {
                var first = this.shareGlucose.First();

                //
                // Converts between share glucose Direction ordinals to nightscout glucose directions
                // which is the expected format
                //
                switch (first.Trend)
                {
                    case ShareGlucoseSlopeOrdinals.DOUBLE_UP:
                        return "DoubleUp";

                    case ShareGlucoseSlopeOrdinals.SINGLE_UP:
                        return "SingleUp";

                    case ShareGlucoseSlopeOrdinals.UP_45:
                        return "FortyFiveUp";

                    case ShareGlucoseSlopeOrdinals.FLAT:
                        return "Flat";

                    case ShareGlucoseSlopeOrdinals.DOWN_45:
                        return "FortifiveDown";

                    case ShareGlucoseSlopeOrdinals.SINGLE_DOWN:
                        return "SingleDown";

                    case ShareGlucoseSlopeOrdinals.DOUBLE_DOWN:
                        return "DoubleDown";

                    case ShareGlucoseSlopeOrdinals.NOT_COMPUTABLE:
                        return "NOT COMPUTABLE";

                    case ShareGlucoseSlopeOrdinals.OUT_OF_RANGE:
                        return "OUT OF RANGE";

                    case ShareGlucoseSlopeOrdinals.NONE:
                        return "None";
                }

                return "";
            }
        }

        public virtual void OnPluginSelected(FormGlucoseSettings form)
        {
            form.lblDataSourceLocation.Text = "Dexcom share server";
            form.txtDataSourceLocation.Text = this.shareClient.CurrentDexcomServer;
        }

        public virtual bool VerifyConfig(Properties.Settings settings)
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

            shareClient.username = username;
            shareClient.password = password;

            /*if (!Validators.IsReadableFile(settings.DataPathLocation))
            {
                throw new ConfigValidationException("You have entered an invalid file path for the data dump!");
            }*/

            return true;
        }

        public virtual async Task<IDataSourcePlugin> GetDataSourceDataAsync(NameValueCollection locations)
        {
            try
            {
                //this can return null if the internet connection is broken

                this.shareGlucose = await shareClient.FetchLast(3);
            }
            catch (SpecificShareError err)
            {
                if (err.code == ShareKnownRemoteErrorCodes.AuthenticateAccountNotFound || err.code == ShareKnownRemoteErrorCodes.AuthenticatePasswordInvalid)
                {
                    MessageBox.Show($"Dexcom share client uknown username or password. Entered username: {shareClient.username}", AppShared.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return this;
        }
    }
}