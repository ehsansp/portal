using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShahrKoodak.DataLayer.Entities.Product
{
    public class UserProduct
    {
        [Key]
        public int US_Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }


        public product Product { get; set; }
        public User.User User { get; set; }
    }
}
