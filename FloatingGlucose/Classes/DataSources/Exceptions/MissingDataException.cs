using System;
using System.Linq;
using System.Text;

namespace FloatingGlucose.Classes.DataSources
{
    internal class MissingDataException : Exception
    {
        public MissingDataException(string message) : base(message)
        {
        }

        public MissingDataException()
        {
        }

        public MissingDataException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}