using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShahrKoodak.DataLayer.Entities.Product
{
    public class ProductVizhegi
    {
        [Key]
        public int VizhegiId { get; set; }
        public int ProductId { get; set; }
        [Display(Name = "نام")][Required(ErrorMessage = "لطفاً {0} را وارد کنید.")][MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Name { get; set; }

        public product Product { get; set; }

    }
}
