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
    internal class DexcomShareNonUSEndpoint : DexcomShareEndpoint
    {
        protected new ShareClient shareClient = new ShareClient(ShareServer.ServerNonUS);
        public override string DataSourceShortName => "Dexcom Share (Non-US)";

        public override void OnPluginSelected(FormGlucoseSettings form)
        {
            form.lblDataSourceLocation.Text = "Dexcom share server";
            form.txtDataSourceLocation.Text = this.shareClient.CurrentDexcomServer;
        }

        public override bool VerifyConfig(Properties.Settings settings)
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

            /*if (!Validators.IsReadableFile(settings.DataPathLocation))
            {
                throw new ConfigValidationException("You have entered an invalid file path for the data dump!");
            }*/

            return true;
        }

        public override async Task<IDataSourcePlugin> GetDataSourceDataAsync(NameValueCollection locations)
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
                    this.shareGlucose = null;
                    throw new ConfigValidationException($"Dexcom share client uknown username or password. Entered username: {shareClient.Username}");

                }
            }

            return this;
        }
    }
}