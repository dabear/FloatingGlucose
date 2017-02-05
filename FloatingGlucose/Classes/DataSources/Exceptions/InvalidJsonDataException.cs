using System;
using System.Linq;
using System.Text;

namespace FloatingGlucose.Classes.DataSources
{
    internal class InvalidJsonDataException : Exception
    {
        public InvalidJsonDataException(string message) : base(message)
        {
        }

        public InvalidJsonDataException()
        {
        }

        public InvalidJsonDataException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}