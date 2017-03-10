using System;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FloatingGlucose.Classes.Extensions
{
    internal static class ColorExtensions
    {
        public static string ToHexString(this Color color)
        {
            return color.ToArgb().ToString("X");
        }

        public static Color FromHexStringToColor(this String hexColor)
        {
            var argb = Convert.ToInt32(hexColor, 16);
            var color = Color.FromArgb(argb);//FF000000 - black with no transparency
            return color;
        }



    }
}