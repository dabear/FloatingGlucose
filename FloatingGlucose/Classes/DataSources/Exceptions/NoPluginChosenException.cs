using System;

namespace FloatingGlucose.Classes.DataSources
{
    internal class NoPluginChosenException : Exception
    {
        public NoPluginChosenException()
        {
        }

        public NoPluginChosenException(string message) : base(message)
        {
        }
    }
}