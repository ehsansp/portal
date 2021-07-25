using System;
using System.Collections.Generic;
using System.Text;

namespace ShahrKoodak.Core.DTOs.Product
{
    public  class CityVM
    {
       
            public string level { get; set; }
            public int radius { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string slug { get; set; }
            public int parent { get; set; }
            public bool news { get; set; }
            public string second_slug { get; set; }

        
    }
}
