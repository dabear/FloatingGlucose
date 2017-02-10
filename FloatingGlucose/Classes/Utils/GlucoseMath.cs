using System.Linq;
using System.Text;
using System;

using static FloatingGlucose.Properties.Settings;

namespace FloatingGlucose.Classes.Utils
{
    internal class GlucoseMath
    {
        public static decimal ToMmol(decimal number)
        {
            return decimal.Round(number / 18.01559M, 1);
        }

        public static decimal ToMgdl(decimal number)
        {
            return decimal.Round(number * 18.01559M, 0);//no decimals for mgdl values
        }

        private static double calculateSlope(BgReading current, BgReading last)
        {
            if (current.Timestamp == last.Timestamp)
            {
                return 0.0;
            }

            return (last._glucose - current._glucose) / (last.Timestamp - current.Timestamp);
        }

        private static double calculateSlopeByMinute(BgReading current, BgReading last)
        {
            return calculateSlope(current, last) * 60000;
        }

        public static string GetGlucoseDirection(BgReading current, BgReading last)
        {
            //converted from:
            //https://github.com/NightscoutFoundation/xDrip/blob/b34e63223573a367105b31536e413d4b83b78dab/app/src/main/java/com/eveningoutpost/dexdrip/Models/BgReading.java#L563

            double sloapPerMinute = calculateSlopeByMinute(current, last);

            String arrow = "Unknown";
            if (sloapPerMinute <= (-3.5))
            {
                arrow = "DoubleDown";
            }
            else if (sloapPerMinute <= (-2))
            {
                arrow = "SingleDown";
            }
            else if (sloapPerMinute <= (-1))
            {
                arrow = "FortyFiveDown";
            }
            else if (sloapPerMinute <= (1))
            {
                arrow = "Flat";
            }
            else if (sloapPerMinute <= (2))
            {
                arrow = "FortyFiveUp";
            }
            else if (sloapPerMinute <= (3.5))
            {
                arrow = "SingleUp";
            }
            else if (sloapPerMinute <= (40))
            {
                arrow = "DoubleUp";
            }
            return arrow;
        }

        public static GlucoseAlarmStatusEnum GetGlucoseAlarmStatus(decimal glucose)
        {
            if (!Default.EnableAlarms)
            {
                return GlucoseAlarmStatusEnum.Normal;
            }
            decimal urgentHigh = Default.AlarmUrgentHigh;
            decimal high = Default.AlarmHigh;
            decimal low = Default.AlarmLow;
            decimal urgentLow = Default.AlarmUrgentLow;

            if (glucose <= urgentLow)
            {
                return GlucoseAlarmStatusEnum.UrgentLow;
            }
            else if (glucose <= low)
            {
                return GlucoseAlarmStatusEnum.Low;
            }
            else if (glucose <= high)
            {
                return GlucoseAlarmStatusEnum.Normal;
            }
            else if (glucose <= urgentHigh)
            {
                return GlucoseAlarmStatusEnum.High;
            }
            else if (glucose >= urgentHigh)
            {
                return GlucoseAlarmStatusEnum.UrgentHigh;
            }

            return GlucoseAlarmStatusEnum.Unknown;
        }
    }
}