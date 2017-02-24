using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexcomShareNet
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Test");

            DoIt();
            Console.Read();
        }

        private static async void DoIt()
        {
            var debug = false;
            string user = "somevaliduser";
            string password = "somevalidpassword";

            //testtoken, this token was valid 2017-02-24 13:00 Norway time
            string testtoken = "sometoken";

            //testtoken, should be correct format, but invalid number
            string testtoken2 = "someothertoken";

            if (debug)
            {
                user = "baribari2402207X";//obviously incorrect
                password = "bazbar"; //obviously incorrect
            }
            var client = new ShareClient(user, password);

            try
            {
                // var token = await client.fetchToken();
                //this will login, fetch token and send a request to fetch
                //glucose values using that token.
                //manually setting the client.token is only recommended for testing purposes!

                var glucose = await client.FetchLastGlucoseValues();

                //set client.token manually, test with a valid token
                client.token = testtoken;

                //set client.token manually, test with an invalid token
                client.token = testtoken2;
                var glucose2 = await client.FetchLastGlucoseValues();
            }
            catch (SpecificShareError err)
            {
                Console.WriteLine($"Got specific error:{err}: {err.Message}");
            }
            catch (Exception err)
            {
                Console.WriteLine($"got generic error of type {err.GetType()}: {err.Message}");
            }
        }
    }
}