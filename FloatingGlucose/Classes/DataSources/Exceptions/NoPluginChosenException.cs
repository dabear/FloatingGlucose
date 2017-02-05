using System;
using System.Runtime.Serialization;

namespace FloatingGlucose.Classes.DataSources
{
    
    class NoPluginChosenException : Exception
    {
        public NoPluginChosenException()
        {
        }

        public NoPluginChosenException(string message) : base(message)
        {
        }

       
    }
}