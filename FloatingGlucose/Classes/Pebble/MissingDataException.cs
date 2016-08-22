using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatingGlucose.Classes.Pebble
{
    class MissingDataException : Exception
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
