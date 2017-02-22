using FloatingGlucose.Classes.DataSources;
using System.Linq;
using System.Text;
using System;
using static FloatingGlucose.Properties.Settings;
using System.Diagnostics;

namespace FloatingGlucose.Classes.Extensions
{
    internal static class IDataSourcePluginExtensions
    {
        public static bool UserWantsMmolUnits(this IDataSourcePlugin plugin) => Default.GlucoseUnits == "mmol";

        public static string FormattedDelta(this IDataSourcePlugin plugin)
        {
            return $"{(plugin.RoundedDelta() >= 0.0 ? "+" : "")}{plugin.RoundedDelta():N1}";
        }

        public static string FormattedRawDelta(this IDataSourcePlugin plugin)
        {
            return $"{(plugin.RoundedRawDelta() >= 0.0 ? "+" : "")}{plugin.RoundedRawDelta():N1}";
        }

        public static void WriteDebug(this IDataSourcePlugin plugin, string line)
        {
            var now = DateTime.Now.ToUniversalTime();
            Debug.WriteLine(now + ":" + line);
        }

        public static string DirectionArrow(this IDataSourcePlugin plugin)
        {
            switch (plugin.Direction)
            {
                case "DoubleUp":
                    return "⇈";

                case "SingleUp":
                    return "↑";

                case "FortyFiveUp":
                    return "↗";

                case "Flat":
                    return "→";

                case "FortyFiveDown":
                    return "↘";

                case "SingleDown":
                    return "↓";

                case "DoubleDown":
                    return "⇊";

                case "NOT COMPUTABLE":
                    return "-";

                case "RATE OUT OF RANGE":
                    return "⇕";

                case "":
                    return "";

                default:
                case "None":
                    return "⇼";
            }
        }
    }
}