using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatingGlucose.Classes.Pebble
{
    //json2csharp.com
    public class GeneratedNsData
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
        public double filtered { get; set; }
        public double unfiltered { get; set; }
        public double noise { get; set; }
        public string bgdelta { get; set; }
        public string battery { get; set; }
    }

    public class Cal
    {
        public double slope { get; set; }
        public double intercept { get; set; }
        public double scale { get; set; }
    }

}
