using System;
using System.Collections.Generic;
using System.Text;

namespace ShahrKoodak.DataLayer.Entities.Product
{
    public class Region
    {
        public int RegionId { get; set; }
        public string Name { get; set; }
        public int OstanId { get; set; }

        public List<product> Products { get; set; }
    }
}
