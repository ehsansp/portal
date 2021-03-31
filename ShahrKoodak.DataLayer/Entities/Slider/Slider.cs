using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShahrKoodak.DataLayer.Entities.Slider
{
    public class Slider
    {
        [Key]
        public int SliderId { get; set; }
        [Display(Name = "تصویر اسلایدر")][Required(ErrorMessage = "لطفاً {0} را وارد کنید.")][MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string SliderImageName { get; set; }
        [Display(Name = "متن 1")][MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Text1 { get; set; }
        [Display(Name = "متن 2")][MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Text2 { get; set; }
        [Display(Name = "متن 3")][MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Text3 { get; set; }
        [Display(Name = "آدرس لینک")][MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string LinkAddress { get; set; }
    }
}
