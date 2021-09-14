using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.SiteSetting
{
    public class CreateModel : PageModel
    {
        private ISiteSettingService _siteSettingService;

        public CreateModel(ISiteSettingService siteSettingService)
        {
            _siteSettingService = siteSettingService;
        }
        public PortalBuilder.Models.SiteSetting SiteSetting { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(IFormFile imgCourseUp)
        {
            if (!ModelState.IsValid)
                return Page();

            _siteSettingService.AddSiteSetting(SiteSetting, imgCourseUp);

            return RedirectToPage("Index");
        }
    }
}
