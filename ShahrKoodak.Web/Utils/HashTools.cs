using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShahrKoodak.Web.Utils
{
    public static class HashTools
    {
        public static string Sha1Hash(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            SHA1Managed hash = new SHA1Managed();
            var data = hash.ComputeHash(bytes);
            return data.ToHex();
        }

        public static string Sha256Hash(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hash = new SHA256Managed();
            var data = hash.ComputeHash(bytes);
            return data.ToHex();
        }
    }
}
