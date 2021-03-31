using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShahrKoodak.DataLayer.Entities.Product
{
    public class TypeAd
    {
        [Key]
        public int typeAdId { get; set; }

        [MaxLength(150, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public string TypeAdTitle { get; set; }

        public List<product> Products { get; set; }
    }
}
