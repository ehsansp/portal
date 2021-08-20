using System;
using System.Collections.Generic;
using System.Text;

namespace PortalBuilder.Core.Generator
{
    public class NameGenerator
    {
        public static string GenerateUniqeCode()
        {
            return Guid.NewGuid().ToString().Replace("=", "");
        }
    }
}
