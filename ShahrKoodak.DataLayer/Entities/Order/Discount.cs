using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ShahrKoodak.DataLayer.Entities.User;

namespace ShahrKoodak.DataLayer.Entities.Order
{
    public class Discount
    {
        [Key]
        public int DiscountId { get; set; }

        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        [Display(Name = "کد")]
        [MaxLength(150, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string DiscountCode { get; set; }

        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        [Display(Name = "درصد")]
        public int DiscountPercent { get; set; }

        public int? UsableCount { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public List<UserDiscountCode> UserDiscountCodes { get; set; }
    }
}
