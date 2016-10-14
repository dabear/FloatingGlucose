using System;
using System.Runtime.Serialization;

namespace FloatingGlucose.Classes.DataSources
{
    
    class NoSuchPluginException : Exception
    {
        public NoSuchPluginException()
        {
        }

        public NoSuchPluginException(string message) : base(message)
        {
        }

       
    }
}