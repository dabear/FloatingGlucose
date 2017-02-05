using System;

namespace FloatingGlucose.Classes.DataSources
{
    internal class NoSuchPluginException : Exception
    {
        public NoSuchPluginException()
        {
        }

        public NoSuchPluginException(string message) : base(message)
        {
        }
    }
}