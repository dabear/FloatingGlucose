using System;
using System.IO;
using System.Linq;
using System.Text;

namespace FloatingGlucose.Classes.Utils
{
    internal class Validators
    {
        public static bool IsUrl(string url)
        {
            var isWellFormed = url != null && Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute);
            if (!isWellFormed)
            {
                return false;
            }
            System.Uri uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult) &&
                (
                    (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps)
                );
        }

        public static bool IsReadableFile(string path)
        {
            var isFile = File.Exists(path);
            if (!isFile)
            {
                return false;
            }

            try
            {
                return File.ReadAllBytes(path) != null;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}