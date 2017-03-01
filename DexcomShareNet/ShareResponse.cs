using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareClientDotNet
{
    public class ShareResponse
    {
        private string _response;

        public string Response
        {
            set
            {
                this._response = value;
            }
        }

        public string GetResponse()
        {
            this.ThrowAnyShareError();
            return this._response;
        }

        public bool IsSuccess = false;

        public Dictionary<string, string> errors
        {
            get
            {
                if (!this.IsSuccess && this._response != null && this._response.Length > 0)
                {
                    try
                    {
                        return JsonConvert.DeserializeObject<Dictionary<string, string>>(this._response);
                    }
                    catch (JsonReaderException err)
                    {
                        return new Dictionary<string, string>()
                        {
                            {"code", "Unknown" },
                            {"Message", this._response ?? "Unknown Error occured in accessing dexcom url/decoding data" }
                        };
                    }
                }
                return null;
            }
        }

        private void ThrowAnyShareError()
        {
            if (!this.IsSuccess)
            {
                string code;
                string message;
                this.errors.TryGetValue("Code", out code);
                this.errors.TryGetValue("Message", out message);

                throw new SpecificShareError(message ?? "Generic Share Client Fault", code ?? "Unknown");
            }
        }
    }
}