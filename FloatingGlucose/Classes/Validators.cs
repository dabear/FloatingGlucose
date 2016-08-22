using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatingGlucose.Classes
{
    class Validators
    {
        public static bool IsUrl(string url) => url != null && Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute);
            
    }
}
