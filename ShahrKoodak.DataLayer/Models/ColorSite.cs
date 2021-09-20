using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PortalBuilder.DataLayer.Models
{
    public class ColorSite
    {
        [Key]
        public int ColorId { get; set; }
        public string Name { get; set; }


    }
}
