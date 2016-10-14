using System;
using System.Runtime.Serialization;

namespace FloatingGlucose.Classes.DataSources
{
    [Serializable]
    internal class ConfigValidationError : Exception
    {
        public ConfigValidationError()
        {
        }

        public ConfigValidationError(string message) : base(message)
        {
        }

        public ConfigValidationError(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConfigValidationError(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}