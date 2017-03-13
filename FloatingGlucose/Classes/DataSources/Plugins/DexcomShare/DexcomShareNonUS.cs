using ShareClientDotNet;
using System.Linq;
using System.Text;

namespace FloatingGlucose.Classes.DataSources.Plugins
{
    internal class DexcomShareNonUSEndpoint : DexcomShareEndpoint
    {
        //protected new ShareClient shareClient = new ShareClient(ShareServer.ServerNonUS);
        public override string DataSourceShortName => "Dexcom Share (Non-US)";

        public DexcomShareNonUSEndpoint()
        {
            this.shareClient.SetShareServer(ShareServer.ServerNonUS);
        }
    }
}