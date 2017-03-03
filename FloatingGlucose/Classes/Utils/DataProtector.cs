using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FloatingGlucose.Classes.Utils
{
    [TypeConverter(typeof(DataProtectorConverter))]
    [SettingsSerializeAs(SettingsSerializeAs.String)]
    public class DataProtector
    {
        /// <summary>
        /// This class implements some of the best practices for generating a secure string that can only be read
        /// by the current user. However, as it is untested security wise, this can only be considered as secure as
        /// a two way hash, where the encrpytion key is stored on a per user setting.
        ///
        /// </summary>

        private static BitArray aditionalEntropy = new BitArray(new byte[7] { 64, 3, 16, 32, 28, 99, 33 });
        private static BitArray nr2 = new BitArray(new byte[7] { 7, 9, 3, 2, 8, 9, 3 });

        public string Text { get; set; }

        public DataProtector()
        {
        }

        public DataProtector(string text)
        {
            this.Text = text;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string ConvertToSecureTextString(string password)
        {
            var data = System.Text.ASCIIEncoding.Default.GetBytes(password);
            var converted = ConvertToBytes((aditionalEntropy.Clone() as BitArray).Xor(nr2));
            var protecteddata = ProtectedData.Protect(data, converted, DataProtectionScope.CurrentUser);
            return System.Text.Encoding.Default.GetString(protecteddata);
        }

        public static string ConvertFromSecureTextString(string securestring)
        {
            var data = System.Text.ASCIIEncoding.Default.GetBytes(securestring);
            var converted = ConvertToBytes((aditionalEntropy.Clone() as BitArray).Xor(nr2));
            var unprotecteddata = ProtectedData.Unprotect(data, converted, DataProtectionScope.CurrentUser);

            return System.Text.Encoding.Default.GetString(unprotecteddata);
        }

        public static byte[] ConvertToBytes(BitArray bits)
        {
            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);
            return ret;
        }

        public static string ConvertByteArrayToIntString(byte[] array)
        {
            return ((Int32)(BitConverter.ToInt16(array, 0))).ToString();
        }
    }
}