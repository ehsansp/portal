using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShahrKoodak.Web.Utils
{
    public static class SecurityTools
    {
        public static string CalculatePaymentHash(string apiKey, string orderNo)
        {
            return HashTools.Sha256Hash($"{apiKey}:{orderNo}");
        }

        public static bool VerifyPaymentHash(string apiKey, string orderNo, string hash)
        {
            return string.Equals(CalculatePaymentHash(apiKey, orderNo), hash);
        }
    }
}
