using FloatingGlucose.Classes.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatingGlucose.Classes.Utils
{
    internal class BgReading
    {
        public double _glucose;
        public DateTime DateReading;

        public double timestamp => this.DateReading.ToUnixTimeStampMilliseconds();
        public double GlucoseMgdl => this._glucose;
        public double GlucoseMmol => this.GlucoseMgdl / 18.01559;

        public string GetRelativeGlucoseDirection(BgReading otherReading)
        {
            return GlucoseMath.GetGlucoseDirection(this, otherReading);
        }
    }
}