using System.Linq;
using System.Text;
using System;

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

    internal class GlucoseStatus
    {
        public static decimal ToMmol(decimal number)
        {
            return decimal.Round(number / 18.01559M, 1);
        }

        public static decimal ToMgdl(decimal number)
        {
            return decimal.Round(number * 18.01559M, 0);//no decimals for mgdl values
        }

        public static GlucoseStatusEnum GetGlucoseStatus(decimal glucose)
        {
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
            else if (glucose <= high)
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