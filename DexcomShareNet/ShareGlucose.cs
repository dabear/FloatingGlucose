using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexcomShareNet
{
    //json2csharp.com
    internal class ShareGlucose
    {
        public DateTime DT { get; set; }
        public DateTime ST { get; set; }
        public long Trend { get; set; }
        public long Value { get; set; }
        public DateTime WT { get; set; }
    }
}