using FloatingGlucose.Classes.Extensions;
using ShareClientDotNet;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var reading = this.shareGlucose?.First();
                if (reading == null)
                {
                    return 0;
                }
                return Convert.ToDouble(this.UserWantsMmolUnits() ? reading.ValueMmol : reading.ValueMgdl);
            }
        }

        protected ShareClient shareClient = new DebuggableShareClient();

        protected List<ShareGlucose> shareGlucose = new List<ShareGlucose>();

        public double PreviousGlucose
        {
            get
            {
                var reading = this.shareGlucose?.Skip(1)?.First();
                if (reading == null)
                {
                    return 0;
                }
                return Convert.ToDouble(this.UserWantsMmolUnits() ? reading.ValueMmol : reading.ValueMgdl);
            }
        }

        public string Direction
        {
            get
            {
                var first = this.shareGlucose?.First();

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
                        return "FortyFiveDown";

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

            form.lblUsername.Text = "User Name";
            form.lblPassword.Enabled = true;
            form.txtPassword.Enabled = true;
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

            shareClient.Username = username;
            shareClient.Password = password;

            return true;
        }

        public virtual async Task<IDataSourcePlugin> GetDataSourceDataAsync(NameValueCollection locations)
        {
            try
            {
                //this can return null if the internet connection is broken
                Console.WriteLine($"Will attempt {this.shareClient.CurrentDexcomServer}, user: {shareClient.Username}");
                this.shareGlucose = await shareClient.FetchLast(3);
            }
            catch (SpecificShareError err)
            {
                if (err.code == ShareKnownRemoteErrorCodes.AuthenticateAccountNotFound || err.code == ShareKnownRemoteErrorCodes.AuthenticatePasswordInvalid)
                {
                    this.shareGlucose = null;
                    throw new ConfigValidationException($"Dexcom share client uknown username or password. Entered username: {shareClient.Username}");
                }
            }

            return this;
        }
    }
}
