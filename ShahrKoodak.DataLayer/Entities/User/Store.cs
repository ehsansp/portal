using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ShahrKoodak.DataLayer.Entities.Product;

namespace ShahrKoodak.DataLayer.Entities.User
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public int GroupId { get; set; }
        public int? SubGroup { get; set; }
        public int UserId { get; set; }
        [Display(Name = "بنر فروشگاه")]
        public string Banner { get; set; }
        [Display(Name = "لوگوی فروشگاه")]
        public string Logo { get; set; }
        [Display(Name = "نام فروشگاه")][MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Name { get; set; }
        [Display(Name = "شعار")][MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Shoar { get; set; }
        [Display(Name = "توضیحات")][MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Description { get; set; }
        [Display(Name = "اینستاگرام")][MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Instagram { get; set; }
        [Display(Name = "تلگرام")][MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Telegram { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("GroupId")]
        public ProductGroup ProductGroup { get; set; }

        [ForeignKey("SubGroup")]
        public ProductGroup Group { get; set; }

        public List<Store> Stores { get; set; }


    }
}
