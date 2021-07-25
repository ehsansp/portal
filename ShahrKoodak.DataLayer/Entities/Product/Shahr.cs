using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ShahrKoodak.DataLayer.Entities.User;

namespace ShahrKoodak.DataLayer.Entities.Product
{
    public class Shahr
    {
        [Key]
        public int ShahrId { get; set; }

        [Display(Name = "استان")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string GroupTitle { get; set; }

        [Display(Name = "حذف شده؟")]
        public bool IsDelete { get; set; }

        [Display(Name = "گروه اصلی")]
        public int? ParentId { get; set; }

        public string slug { get; set; }
        




        [InverseProperty("Shahr")]
        public List<product> Products { get; set; }

        [InverseProperty("Sh")]
        public List<product> Sh { get; set; }




       
      
    }
}
