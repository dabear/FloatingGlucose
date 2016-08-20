using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static FloatingGlucose.Properties.Settings;
namespace FloatingGlucose.Classes
{
    public enum GlucoseStatusEnum
    {
        UrgentLow,
        Low,
        Normal,
        High,
        UrgentHigh,
        Unknown
    }

    class GlucoseStatus
    {
        public static decimal toMMOL(decimal number) {
            return number / 18.0M;
        }
        public static decimal toMGDL(decimal number) {
            return number * 18.0M;
        }
        public static GlucoseStatusEnum GetGlucoseStatus(decimal glucose) {
            if (!Default.EnableAlarms)
            {
                return GlucoseStatusEnum.Normal;
            }
            decimal urgentHigh = Default.AlarmUrgentHigh;
            decimal high = Default.AlarmHigh;
            decimal low = Default.AlarmLow;
            decimal urgentLow = Default.AlarmUrgentLow;

            if (glucose <= urgentLow)
            {
                return GlucoseStatusEnum.UrgentLow;
            }
            else if (glucose <= low)
            {
                return GlucoseStatusEnum.Low;
            }
            else if (glucose <= high )
            {
                return GlucoseStatusEnum.Normal;
            }
            else if (glucose <= urgentHigh)
            {
                return GlucoseStatusEnum.High;
            }
            else if (glucose >= urgentHigh)
            {
                return GlucoseStatusEnum.UrgentHigh;
            }
            

            return GlucoseStatusEnum.Unknown;

        }
    }
}
