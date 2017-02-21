using FloatingGlucose.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloatingGlucose
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class FormWebbrowser : Form
    {
        private string injectScript = "";

        //private string _webpageReturnValue = "/place/Norway/Sør-Trøndelag/Trondheim/Trondheim/";
        private string _webpageReturnValue = "";

        public string WebPageReturnValue => this._webpageReturnValue;

        private bool disableScrollBars = true;

        public void SetReturnValueAndClose(string value)
        {
            this._webpageReturnValue = value;
            this.Close();
        }

        public FormWebbrowser(string injectScript, bool disableScrollBars = true)
        {
            InitializeComponent();
            this.injectScript = injectScript;

            var wb = this.webBrowser1;

            wb.ObjectForScripting = this;

            if (!AppShared.isDebuggingBuild)
            {
                wb.AllowWebBrowserDrop = false;
                wb.IsWebBrowserContextMenuEnabled = false;
                wb.WebBrowserShortcutsEnabled = false;
            }

            wb.ScriptErrorsSuppressed = !AppShared.isDebuggingBuild;
        }

        public void SetBrowserUrl(string url)
        {
            this.webBrowser1.Url = new Uri(url);
        }

        public string InvokeScript(string scriptName)
        {
            return this.webBrowser1.Document.InvokeScript(scriptName).ToString();
        }

        private void FormWebbrowser_Load(object sender, EventArgs e)
        {
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var doc = this.webBrowser1.Document;

            if (this.injectScript != null)
            {
                var head = doc.GetElementsByTagName("head")[0];
                var s = doc.CreateElement("script");
                s.SetAttribute("text", this.injectScript);
                head.AppendChild(s);
                Debug.WriteLine("Inserted script into web page!");
            }
            if (this.disableScrollBars)
            {
                doc.Body.Style = "overflow:hidden";
            }
        }
    }
}