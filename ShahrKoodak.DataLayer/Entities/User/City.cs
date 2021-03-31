using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShahrKoodak.DataLayer.Entities.User
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }

        public virtual List<User> Users { get; set; }
    }
}
