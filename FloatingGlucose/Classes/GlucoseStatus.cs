using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
            if (!Properties.Settings.Default.enable_alarms)
            {
                return GlucoseStatusEnum.Normal;
            }
            decimal urgentHigh = Properties.Settings.Default.alarm_urgent_high;
            decimal high = Properties.Settings.Default.alarm_high;
            decimal low = Properties.Settings.Default.alarm_low;
            decimal urgentLow = Properties.Settings.Default.alarm_urgent_low;

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
