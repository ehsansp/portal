using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShahrKoodak.DataLayer.Entities.Slider
{
    public class RightBanner2
    {
        [Key]
        public int RightBannerId { get; set; }
        [Display(Name = "تصویر بنر")]
        [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string ImageName { get; set; }
        [Display(Name = "لینک بنر")]
        [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string BennerLink { get; set; }
    }
}
