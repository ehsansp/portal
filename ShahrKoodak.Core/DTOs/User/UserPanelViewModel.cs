using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace ShahrKoodak.Core.DTOs.User
{
    public class InformationUserViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public decimal Wallet { get; set; }
        public decimal btc { get; set; }
        public decimal doge { get; set; }
        public decimal eth { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Mail { get; set; }
        public string Tel { get; set; }
        public string WhatsApp { get; set; }
        public string WebSite { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
    }

    public class InformationAdViewModel
    {
        public int ProductId { get; set; }
        public int TypeAdId { get; set; }
        public DateTime RegisterDate { get; set; }
        public int GroupId { get; set; }
        public int? SubGroup { get; set; }
        public string ProductName { get; set; }
        public bool PriceType { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public IFormFile ProductImage { get; set; }
        public int CityId  { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string WhatsApp { get; set; }
        public string Email { get; set; }
        public bool IsShowMobile { get; set; }
    }

    public class InformationStoreViewModel
    {
        public int GroupId { get; set; }
        public int SubGroup { get; set; }
        public IFormFile BannerFile { get; set; }
        public IFormFile LogoFile { get; set; }
        public string Banner { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Shoar { get; set; }
        public string Description { get; set; }
        public string Instagram { get; set; }
        public string Telegram { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string WebSite { get; set; }
        public string Address { get; set; }
        public string WhatsApp { get; set; }
        public string Lat { get; set; }
        public string Lut { get; set; }
    }
    public class EditProfileViewModel
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string UserName { get; set; }

        [Display(Name = "نام")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Family { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Mail { get; set; }

        [Display(Name = "تلفن")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Tel { get; set; }

        [Display(Name = "شماره واتس اپ")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string WhatsApp { get; set; }

        [Display(Name = "وب سایت")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string WebSite { get; set; }

        [Display(Name = "کد پستی")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string PostCode { get; set; }

        [Display(Name = "آدرس")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]

        public IFormFile UserAvatar { get; set; }

        public string AvatarName { get; set; }
    }
}
