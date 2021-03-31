using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ShahrKoodak.DataLayer.Entities.Order;

namespace ShahrKoodak.DataLayer.Entities.Product
{
    public class product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public int GroupId { get; set; }
        [Required]
        public int UserId { get; set; }

        public int Counter { get; set; }
        public int? SubGroup { get; set; }
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public int TypeAdId { get; set; }

        [Display(Name = "عنوان محصول")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string ProductTitle { get; set; }

        [Display(Name = "عنوان محصول")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string ProductTitle2 { get; set; }

        [Display(Name = "عنوان محصول")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string ProductTitle3 { get; set; }


        [Display(Name = "عنوان محصول")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Tel1 { get; set; }

        [Display(Name = "عنوان محصول")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Tel2 { get; set; }

        [Display(Name = "عنوان محصول")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Tel3 { get; set; }

        [Display(Name = "عنوان محصول")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Mobile { get; set; }

        [Display(Name = "عنوان محصول")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public int Mantaghe { get; set; }

        [Display(Name = "توافقی")]
        public bool PriceType { get; set; }
        [Display(Name = "قیمت محصول")]
        public int Price { get; set; }

        [Display(Name = "توضیحات محصول")]
        public string ProductDescription { get; set; }

        [Display(Name = "شرح کوتاه")]
        public string ShortDescription { get; set; }

        public int StarNumber { get; set; }

        [MaxLength(600, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Tags { get; set; }

        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string ProductImageName { get; set; }

        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string DemoFileName { get; set; }

        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        public bool IsShowTel { get; set; }

        #region Relations
        [ForeignKey("OtherCourse")]
        public int? OtherProduct { get; set; }

        [ForeignKey("OtherCourse2")]
        public int? OtherProduct2 { get; set; }


        [ForeignKey("OtherCourse3")]
        public int? OtherProduct3 { get; set; }

        public List<product> Products { get; set; }

        [ForeignKey("GroupId")]
        public ProductGroup ProductGroup { get; set; }

        [ForeignKey("SubGroup")]
        public ProductGroup Group { get; set; }

        public List<ProductEpisode> ProductEpisodes { get; set; }
        public List<ProductSharayet> ProductSharayets { get; set; }
        public List<ProductVizhegi> ProductVizhegis { get; set; }
        public List<Package> Packages { get; set; }
        public TypeAd TypeAd { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public List<UserProduct> UserProducts { get; set; }

        public List<ProductComment> ProductComments { get; set; }

        public List<ProductFeature> ProductFeatures { get; set; }
        

        #endregion
    }
}
