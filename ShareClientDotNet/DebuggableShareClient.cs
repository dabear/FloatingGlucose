using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ShareClientDotNet
{
    internal class DebuggableShareClient : ShareClient
    {
        private Action<string> debugger;

        public DebuggableShareClient(string username, string password, ShareServer shareServer = ShareServer.ShareServerUS, Action<string> handler = null) : base(username, password, shareServer)
        {
            this.enableDebug = true;
            if (handler != null)
            {
                this.debugger = handler;
            }
        }

        protected override void WriteDebug(string msg)
        {
            if (this.debugger == null || !this.enableDebug)
            {
                base.WriteDebug(msg);
            }
            else
            {
                this.debugger(msg);
            }
        }
    }
}