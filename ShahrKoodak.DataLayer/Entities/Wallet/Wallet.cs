using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShahrKoodak.DataLayer.Entities.Wallet
{
    public class Wallet
    {
        public Wallet()
        {

        }

        [Key]
        public int WalletId { get; set; }

        [Display(Name = "نوع تراکنش")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public int TypeId { get; set; }

        [Display(Name = "کاربر")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public int UserId { get; set; }

        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public decimal Amount { get; set; }

        [Display(Name = "بیت کوین")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public decimal btc { get; set; }

        [Display(Name = "اتریوم")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public decimal eth { get; set; }

        [Display(Name = "دوج")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public decimal doge { get; set; }

        [Display(Name = "توضیح")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Description { get; set; }

        [Display(Name = "تایید شده")]
        public bool IsPay { get; set; }

        [Display(Name = "تاریخ و ساعت")]
        public DateTime CreateDate { get; set; }


        public virtual User.User User { get; set; }
        public virtual WalletType WalletType { get; set; }

    }
}
