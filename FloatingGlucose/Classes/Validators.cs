using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatingGlucose.Classes
{
    class Validators
    {
        public static bool isUrl(string url) {
            if (url == null) {
                return false;
            }
            return Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute);

        }
    }
}
