using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace ShahrKoodak.Core.DTOs.User
{
    public class UsersForAdminViewModel
    {
        public List<DataLayer.Entities.User.User> Users { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }

    public class UsersViewModel
    {
        public class CreateUserViewModel
        {
            [Display(Name = "نام کاربری")]
            [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
            [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
            public string UserName { get; set; }

            [Display(Name = "ایمیل")]
            [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
            [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
            [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد.")]
            public string Email { get; set; }

            [Display(Name = "کلمه عبور")]
            [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
            [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
            public string Password { get; set; }

            public IFormFile UserAvatar { get; set; }


        }

        public class PasswordViewModel
        {
            [Display(Name = "کلمه عبور")]
            [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
            public string Password { get; set; }

            [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند.")]
            [Display(Name = "تکرار کلمه عبور")]
            [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
            public string RePassword { get; set; }
        }

        public class ReferalViewModel
        {
            public int UserId { get; set; }
        }

        public class EditUserViewModel
        {
            public int UserId { get; set; }

            public string UserName { get; set; }

            [Display(Name = "ایمیل")]
            [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
            [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
            [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد.")]
            public string Email { get; set; }

            [Display(Name = "کلمه عبور")]
            [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
            [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
            public string Password { get; set; }

            public IFormFile UserAvatar { get; set; }

            public List<int> UserRoles { get; set; }
            public string ActiveCode { get; set; }

            public string AvatarName { get; set; }
        }

        public class ActiveViewModel
        {
            public string code { get; set; }
        }

        public class ChangePassword
        {
            [Display(Name = "کلمه عبور")]
            [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
            [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
            public string Password { get; set; }

            [Display(Name = "تکرار کلمه عبور")]
            [Required(ErrorMessage = "لطفاً {0} را وارد کنید.")]
            [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد.")]
            [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند.")]
            public string RePassword { get; set; }
        }

    }
}
