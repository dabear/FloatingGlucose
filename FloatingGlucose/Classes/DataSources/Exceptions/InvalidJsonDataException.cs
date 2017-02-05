using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatingGlucose.Classes.DataSources
{
    class InvalidJsonDataException : Exception
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
