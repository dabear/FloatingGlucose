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
    }
}