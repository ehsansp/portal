using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ShahrKoodak.Core.Security;

namespace ShahrKoodak.Core.Security
{
    public abstract class GoogleReCaptchaModelBase
    {
        [Required]
        [GoogleReCaptchaValidation]
        [BindProperty(Name = "g-recaptcha-response")]
        public String GoogleReCaptchaResponse { get; set; }
    }
}
