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
        public static GlucoseStatusEnum GetGlucoseStatus(string glucose) {
            if (!Properties.Settings.Default.enable_alarms) {
                return GlucoseStatusEnum.Normal;
            }
            decimal res;
            decimal urgentHigh = Properties.Settings.Default.alarm_urgent_high;
            decimal high = Properties.Settings.Default.alarm_high;
            decimal low = Properties.Settings.Default.alarm_low;
            decimal urgentLow = Properties.Settings.Default.alarm_urgent_low;

            var tryres = decimal.TryParse(glucose, NumberStyles.Any, new CultureInfo("en-US"), out res);
            if (tryres) {
                if (res <= urgentLow) {
                    return GlucoseStatusEnum.UrgentLow;
                } else if (res <= low) {
                    return GlucoseStatusEnum.Low;
                }
                else if (res <= high )
                {
                    return GlucoseStatusEnum.Normal;
                }
                else if (res <= urgentHigh)
                {
                    return GlucoseStatusEnum.High;
                }
                else if (res >= urgentHigh)
                {
                    return GlucoseStatusEnum.UrgentHigh;
                }

            }
            

            return GlucoseStatusEnum.Unknown;

        }
    }
}
