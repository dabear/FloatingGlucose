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
    internal class ShareClient
    {
        protected string dexcomUserAgent = "Dexcom Share/3.0.2.11 CFNetwork/711.2.23 Darwin/14.0.0";
        protected string dexcomApplicationId = "d89443d2-327c-4a6f-89e5-496bbb0317db";
        protected string dexcomLoginPath = "/ShareWebServices/Services/General/LoginPublisherAccountByName";
        protected string dexcomLatestGlucosePath = "/ShareWebServices/Services/Publisher/ReadPublisherLatestGlucoseValues";

        protected string dexcomServerUS = "https://share1.dexcom.com";
        //private string dexcomServerUS = "https://example.com";

        protected string dexcomServerNonUS = "https://shareous1.dexcom.com";

        protected string dexcomServer;

        protected int maxReauthAttempts = 3;
        protected int sleepBetweenRetries = 1000;

        protected string username;
        protected string password;

        protected string token;

        protected bool enableDebug = false;

        protected virtual void WriteDebug(string msg)
        {
            if (!this.enableDebug)
            {
                return;
            }
            Console.WriteLine(nameof(ShareClient) + ": " + msg);
        }

        protected async Task<ShareResponse> dexcomPOST(string url, Dictionary<string, string> data = null)
        {
            return await this.dexcomPOST(new Uri(url), data);
        }

        protected async Task<ShareResponse> dexcomPOST(Uri url, Dictionary<string, string> data = null)
        {
            var json = JsonConvert.SerializeObject(data);
            var client = new HttpClient();

            var msg = new HttpRequestMessage(new HttpMethod("POST"), url);

            msg.Headers.Accept.Clear();
            msg.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            msg.Headers.UserAgent.Clear();
            msg.Headers.Add("user-agent", this.dexcomUserAgent);

            msg.Content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                WriteDebug($"Sending json {json} to endpoint {url}");
                var response = (await client.SendAsync(msg));
                WriteDebug($"Is response success? {response.IsSuccessStatusCode}");
                var result = await response.Content.ReadAsStringAsync();

                WriteDebug($"Response from endpoint {url}: {result}");
                return new ShareResponse { IsSuccess = response.IsSuccessStatusCode, Response = result };
            }
            catch (Exception err)
            {
                WriteDebug($"Got exception in sending to endpoint {err}");
                throw err;
            }
        }

        public ShareClient(string username, string password, ShareServer shareServer = ShareServer.ShareServerUS)
        {
            this.username = username;
            this.password = password;

            this.dexcomServer = shareServer == ShareServer.ShareServerUS ?
                this.dexcomServerUS :
                this.dexcomServerNonUS;
        }

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

            WriteDebug($"Post to {url}");

            try
            {
                var result = (await this.dexcomPOST(url, data)).GetResponse();
                decoded = JsonConvert.DeserializeObject<string>(result);

                return decoded;
            }
            catch (Exception err)
            {
                WriteDebug($"Could not fetch token because response was not as expected. Network failure, or decoding failure:");
                WriteDebug($"{err.GetType()}: message:{err.Message}");

                throw err;
            }
        }

        public async Task<List<ShareGlucose>> FetchLast(int n)
        {
            return await this.fetchLastGlucoseValuesWithRetries(n, this.maxReauthAttempts);
        }

        //should be private after test
        private async Task<List<ShareGlucose>> fetchLastGlucoseValuesWithRetries(int n = 3, int remaining = 3)
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
                    result = await this.fetchLastGlucoseValues(n);
                }
                catch (WebException)
                {
                    //ignore webexceptions, might mean network is temporarily down, retry
                    WriteDebug("Got webexception, waiting at least 1s before retry");
                    if (this.sleepBetweenRetries > 0)
                    {
                        Thread.Sleep(this.sleepBetweenRetries);
                    }
                }
                catch (HttpRequestException)
                {
                    //ignore webexceptions, might mean network is temporarily down, retry
                    WriteDebug("Got httprequestexception, waiting at least 1s before retry");
                    if (this.sleepBetweenRetries > 0)
                    {
                        Thread.Sleep(this.sleepBetweenRetries);
                    }
                }
                catch (SpecificShareError err)
                {
                    if (err.code == "SessionIdNotFound" || err.code == "SessionNotValid")
                    {
                        // Token is invalid, force trying to fetching new token on next call
                        // to FetchLastGlucoseValues
                        this.token = null;
                        WriteDebug("Session was not valid, must reauth");
                    }
                    else
                    {
                        //rethrow because we don't know how to handle other errors
                        throw err;
                    }
                }
            } while (result == null && remaining-- > 1);

            return result;
        }

        //should be private after testubg
        private async Task<List<ShareGlucose>> fetchLastGlucoseValues(int n = 3)
        {
            if (this.token == null)
            {
                WriteDebug("Fetching token from inside FetchLastGlucoseValues");
                this.token = await this.fetchToken();
                WriteDebug($"Tried getting new access token: {this.token}");
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