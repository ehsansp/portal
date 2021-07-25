using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ShahrKoodak.Core.Security;

namespace ShahrKoodak.Core.DTOs
{
    public class AccountViewModel: GoogleReCaptchaModelBase
    {

    }
    public class RegisterViewModel
    {
        [Display(Name = "نام کاربری")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string UserName { get; set; }

        [Display(Name = "شماره همراه")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        [MaxLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        [MinLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند.")]
        [Display(Name = "تکرار کلمه عبور")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر باشد.")]
        public string RePassword { get; set; }
    }
    public class LoginViewModel
    {
        [Display(Name = "شماره همراه")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        [MaxLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        [MinLength(11, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر باشد.")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Display(Name = "شماره همراه")]
        [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
        [MaxLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
        [MinLength(11, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر باشد.")]
        public string Email { get; set; }
    }
}
