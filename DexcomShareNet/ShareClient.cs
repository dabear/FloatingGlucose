using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DexcomShareNet
{
    internal class ShareClient
    {
        private string dexcomUserAgent = "Dexcom Share/3.0.2.11 CFNetwork/711.2.23 Darwin/14.0.0";
        private string dexcomApplicationId = "d89443d2-327c-4a6f-89e5-496bbb0317db";
        private string dexcomLoginPath = "/ShareWebServices/Services/General/LoginPublisherAccountByName";
        private string dexcomLatestGlucosePath = "/ShareWebServices/Services/Publisher/ReadPublisherLatestGlucoseValues";

        private string dexcomServerUS = "https://share1.dexcom.com";
        //private string dexcomServerUS = "https://example.com";

        private string dexcomServerNonUS = "https://shareous1.dexcom.com";

        private string dexcomServer;

        private int maxReauthAttempts = 2;

        private string username;
        private string password;

        public string token;

        private void WriteDebug(string msg)
        {
            Console.WriteLine(msg);
        }

        private async Task<ShareResponse> dexcomPOST(string url, Dictionary<string, string> data = null)
        {
            return await this.dexcomPOST(new Uri(url), data);
        }

        private async Task<ShareResponse> dexcomPOST(Uri url, Dictionary<string, string> data = null)
        {
            var json = JsonConvert.SerializeObject(data);
            var client = new HttpClient();

            var msg = new HttpRequestMessage(new HttpMethod("POST"), url);

            msg.Headers.Accept.Clear();
            msg.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            msg.Headers.UserAgent.Clear();
            msg.Headers.Add("user-agent", this.dexcomUserAgent);

            WriteDebug($"sending json {json} to endpoint {url}");

            msg.Content = new StringContent(json, Encoding.UTF8, "application/json");
            //msg.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = (await client.SendAsync(msg));

            WriteDebug($"is response success? {response.IsSuccessStatusCode}");
            var result = await response.Content.ReadAsStringAsync();

            WriteDebug($"response from endpoint {url}: {result}");
            return new ShareResponse { IsSuccess = response.IsSuccessStatusCode, Response = result };
        }

        public ShareClient(string username, string password, DexcomShareServer shareServer = DexcomShareServer.DexcomServerUS)
        {
            this.username = username;
            this.password = password;

            this.dexcomServer = shareServer == DexcomShareServer.DexcomServerUS ?
                this.dexcomServerUS :
                this.dexcomServerNonUS;
        }

        public async Task<string> Login() => await this.fetchToken();

        public async Task<string> fetchToken()
        {
            string decoded = null;
            var data = new Dictionary<string, string>()
            {
                { "accountName" , this.username},
                { "password" , this.password},
                { "applicationId" , this.dexcomApplicationId},
            };

            var url = this.dexcomServer + this.dexcomLoginPath;

            WriteDebug($"post to {url}");

            var result = (await this.dexcomPOST(url, data)).GetResponse();
            decoded = JsonConvert.DeserializeObject<string>(result);

            return decoded;
        }

        public async Task<List<ShareGlucose>> FetchLast(int n)
        {
            return await this.FetchLastGlucoseValuesWithRetries(n, this.maxReauthAttempts);
        }

        //should be private after test
        public async Task<List<ShareGlucose>> FetchLastGlucoseValuesWithRetries(int n = 3, int remaining = 3)
        {
            List<ShareGlucose> result = null;
            var i = 0;
            do
            {
                //logic for refetching token/reauth here, but missing currently
                try
                {
                    i++;
                    WriteDebug($"Attempt #{i} to fetch glucose");
                    result = await this.FetchLastGlucoseValues(n);
                }
                catch (WebException)
                {
                    //ignore webexceptions, might mean network is temporarily down, retry
                }
                catch (HttpRequestException)
                {
                    //ignore webexceptions, might mean network is temporarily down, retry
                }
                catch (SpecificShareError err)
                {
                    if (err.code == "SessionIdNotFound" || err.code == "SessionNotValid")
                    {
                        // Token is invalid, force trying to fetching new token on next call
                        // to FetchLastGlucoseValues
                        this.token = null;
                        WriteDebug("Session not found, must reauth");
                    }
                    else
                    {
                        //rethrow because we don't know how to handle other errors
                        throw err;
                    }
                }
            } while (result == null && remaining-- > 0);

            return result;
        }

        //should be private after testubg
        public async Task<List<ShareGlucose>> FetchLastGlucoseValues(int n = 3)
        {
            if (this.token == null)
            {
                WriteDebug("Fetchinng token from inside FetchLastGlucoseValues");
                this.token = await this.fetchToken();
            }

            //
            // We failed to retrieve token, retry will be handled by FetchLastGlucoseValuesWithRetries
            //
            if (this.token == null)
            {
                return null;
            }

            var url = $"{this.dexcomServer}{this.dexcomLatestGlucosePath}?sessionId={this.token}&minutes=1440&maxCount={n}";

            var response = (await this.dexcomPOST(url)).GetResponse();

            var parsed = JsonConvert.DeserializeObject<List<ShareGlucose>>(response);

            return parsed;
        }
    }
}