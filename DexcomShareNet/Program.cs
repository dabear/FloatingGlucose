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

            //use this if you use the Non US servers
            //var client = new ShareClient(user, password, ShareServer.ServerNonUS);

            try
            {
                //this can return null if the internet connection is broken
                var glucose = await client.FetchLast(3);
            }
            catch (SpecificShareError err)
            {

                if (err.code == ShareKnownRemoteErrorCodes.AuthenticateAccountNotFound)
                {
                    //invalid username

                }
                else if (err.code == ShareKnownRemoteErrorCodes.AuthenticatePasswordInvalid)
                {
                    //invalid password

                }
                else if (err.code == ShareKnownRemoteErrorCodes.AuthenticateMaxAttemptsExceeed)
                {
                    //the client will not try to automatically re-authenticate when this happens,
                    //as it will likely fail anyway
                }
                else if (err.code == "Unknown")
                {
                    Console.WriteLine("got unknown error from main program");
                    //some unknown error occured, url might be wrong, or some other error
                }
                else
                {
                    // This should never happen. 
                    // If it does, there is a new Remote error code that we don't know about..
                    Console.WriteLine($"hit else-block, coce: {err.code}, err: {err}");
                }

            }

        }
    }
}