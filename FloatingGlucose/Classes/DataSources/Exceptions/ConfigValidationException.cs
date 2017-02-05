using System;
using System.Runtime.Serialization;

namespace FloatingGlucose.Classes.DataSources
{
    [Serializable]
    internal class ConfigValidationException : Exception
    {
        public ConfigValidationException()
        {
        }

        public ConfigValidationException(string message) : base(message)
        {
        }

        public ConfigValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConfigValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}