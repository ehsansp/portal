using System;
using System.Collections.Generic;
using System.Text;

namespace ShahrKoodak.Core.Generator
{
    public class NameGenerator
    {
        public static string GenerateUniqeCode()
        {
            return Guid.NewGuid().ToString().Replace("=", "");
        }
    }
}
