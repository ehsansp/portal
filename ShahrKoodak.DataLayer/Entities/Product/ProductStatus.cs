using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShahrKoodak.DataLayer.Entities.Product
{
    public  class ProductStatus
    {
        [Key]
        public int ProductStatusId { get; set; }
        public string Title { get; set; }
        public List<product> Products { get; set; }
    }
}
