using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareClientDotNet
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DoIt();
            Console.Read();
        }

        private static async void DoIt()
        {
            var debug = false;
            string user = "somevaliduser";
            string password = "somevalidpassword";

            if (debug)
            {
                user = "baribari2402207X";//obviously incorrect
                password = "bazbar"; //obviously incorrect
            }

            //use this if you use the US servers

            var client = new ShareClient(user, password);

            //Different ways of debugging
            //this will per default write to the console
            //var client = new DebuggableShareClient(user, password)
            //This overrides that and writes a custom message:
            //var client = new DebuggableShareClient(user, password, handler: msg =>
            //{
            //    Console.WriteLine($"overridden: {msg}");
            //});

            //use this if you use the Non US servers
            //var client = new ShareClient(user, password, ShareServer.ServerNonUS);

            var glucose = new List<ShareGlucose>();
            try
            {
                //this can return null if the internet connection is broken
                Console.WriteLine("Main Program: Fetching glucose");
                glucose = await client.FetchLast(3);
            }
            catch (SpecificShareError err)
            {
                if (err.code == ShareKnownRemoteErrorCodes.AuthenticateAccountNotFound)
                {
                    //invalid username
                    Console.WriteLine("Main Program: The account was not found");
                }
                else if (err.code == ShareKnownRemoteErrorCodes.AuthenticatePasswordInvalid)
                {
                    //invalid password
                    Console.WriteLine("Main Program: The account password was invalid");
                }
                else if (err.code == ShareKnownRemoteErrorCodes.AuthenticateMaxAttemptsExceeed)
                {
                    //the client will not try to automatically re-authenticate when this happens,
                    //as it will likely fail anyway
                }
                else if (err.code == "Unknown")
                {
                    Console.WriteLine("Main program: Got unknown error");
                    //some unknown error occured, url might be wrong, or some other error
                }
                else
                {
                    // This should never happen.
                    // If it does, there is a new Remote error code that we don't know about..
                    Console.WriteLine($"Hit else-block, code: {err.code}, err: {err}");
                }
            }
            catch (Exception err)
            {
                Console.WriteLine($"Main Program got general exception: {err.GetType()}: {err}");
            }

            Console.WriteLine($"Main Program: Glucose length: {glucose.Count}");
            Console.WriteLine("Main Program: Finished looking for glucose");
        }
    }
}