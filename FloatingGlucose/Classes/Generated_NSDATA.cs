using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatingGlucose.Classes
{
    //json2csharp.com
    public class Generated_NSDATA
    {
        public List<Status> status { get; set; }
        public List<Bg> bgs { get; set; }
        public List<Cal> cals { get; set; }
    }
    public class Status
    {
        public long now { get; set; }
    }

    public class Bg
    {
        public string sgv { get; set; }
        public int trend { get; set; }
        public string direction { get; set; }
        public long datetime { get; set; }
        public int filtered { get; set; }
        public int unfiltered { get; set; }
        public int noise { get; set; }
        public string bgdelta { get; set; }
        public string battery { get; set; }
    }

    public class Cal
    {
        public double slope { get; set; }
        public int intercept { get; set; }
        public double scale { get; set; }
    }

}
