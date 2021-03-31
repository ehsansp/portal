using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShahrKoodak.DataLayer.Entities.Product
{
    public class ProductEpisode
    {
        [Key]
        public int EpisodeId { get; set; }

        public int ProductId { get; set; }

        [Display(Name = "عنوان بخش")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string EpisodeTitle { get; set; }

        [Display(Name = "زمان")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        public TimeSpan EpisodeTime { get; set; }

        [Display(Name = "فایل")]
        public string EpisodeFileName { get; set; }

        [Display(Name = "رایگان")]
        public bool IsFree { get; set; }

        public product Product { get; set; }
    }
}
