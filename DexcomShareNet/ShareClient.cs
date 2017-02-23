using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexcomShareNet
{
    public enum DexcomShareServer
    {
        DexcomServerUS,
        DexcomServerNonUS
    }

    internal class ShareClient
    {
        private string dexcomUserAgent = "Dexcom Share/3.0.2.11 CFNetwork/711.2.23 Darwin/14.0.0";
        private string dexcomApplicationId = "d89443d2-327c-4a6f-89e5-496bbb0317db";
        private string dexcomLoginPath = "/ShareWebServices/Services/General/LoginPublisherAccountByName";
        private string dexcomLatestGlucosePath = "/ShareWebServices/Services/Publisher/ReadPublisherLatestGlucoseValues";
        private string dexcomServerUS = "https://share1.dexcom.com";
        private string dexcomServerNonUS = "https://shareous1.dexcom.com";

        private string dexcomServer;

        private int maxReauthAttempts = 2;

        private string username;
        private string password;

        private string token;

        private void dexcomPOST(string url, Dictionary<string, string> data = null)
        {
            //data=encoded json
            /*var request = URLRequest(url: url)
            request.httpMethod = "POST"
            request.addValue("application/json", forHTTPHeaderField: "Content-Type")
            request.addValue("application/json", forHTTPHeaderField: "Accept")
            request.addValue(dexcomUserAgent, forHTTPHeaderField: "User-Agent")

            if(data!=null){
              request.httpBody = data
            }
             */
        }

        public ShareClient(string username, string password, DexcomShareServer shareServer = DexcomShareServer.DexcomServerUS)
        {
            this.username = username;
            this.password = password;

            if (shareServer == DexcomShareServer.DexcomServerUS)
            {
                this.dexcomServer = this.dexcomServerUS;
            }
            else
            {
                this.dexcomServer = this.dexcomServerNonUS;
            }
        }

        private string fetchToken()
        {
            var data = new Dictionary<string, string>()
            {
                { "accountName" , this.username},
                { "password" , this.password},
                { "applicationId" , this.dexcomApplicationId},
            };

            var url = this.dexcomServer + this.dexcomLoginPath;
            //do post this.dexcomPOST(url, data)
            //deserialize and return
            return "";
        }

        public void FetchLast(int n)
        {
            this.FetchLastGlucoseValuesWithRetries(n, this.maxReauthAttempts);
        }

        //should be private after test
        public void FetchLastGlucoseValuesWithRetries(int n = 3, int remaining = 3)
        {
            string result;

            do
            {
                //logic for refetching token/reauth here, but missing currently

                result = this.FetchLastGlucoseValues(n);
            } while (result == null && remaining-- > 0);
        }

        //should be private after testubg
        public string FetchLastGlucoseValues(int n = 3)
        {
            //RETRY logic not implemented
            //fetching can fail if token is invalid or expired

            if (this.token == null)
            {
                this.token = this.fetchToken();
            }

            var url = this.dexcomServer + this.dexcomLatestGlucosePath;

            var queryItems = new Dictionary<string, string>()
            {
                { "sessionId" , this.token},
                { "minutes" , "1440"},
                { "maxCount" , $"{n}" },
            };

            //do dexcom post
            //decode result
            //JSON deserialize
            return "";
        }
    }
}