using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShahrKoodak.DataLayer.Entities.Product
{
    public class Package
    {
        [Key]
        public int PackageId { get; set; }

        public int ProductId { get; set; }


        [Display(Name = "نام")][Required(ErrorMessage = "لطفاً {0} را وارد کنید.")][MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string PakageName { get; set; }


        [Display(Name = "درصد")][Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public int Discount { get; set; }


        [Display(Name = "عکس")][Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public string PackageImage { get; set; }


        [Display(Name = "قیمت اصلی")][Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public int Price1 { get; set; }
        [Display(Name = "قیمت تخفیف خورده")][Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public int Price2 { get; set; }

        public product Product { get; set; }
    }
}
