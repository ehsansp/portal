using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShahrKoodak.DataLayer.Entities.Slider
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}
