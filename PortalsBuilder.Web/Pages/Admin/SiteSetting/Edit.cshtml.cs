using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.SiteSetting
{
    public class EditModel : PageModel
    {
        private ISiteSettingService _siteSettingService;

        public EditModel(ISiteSettingService siteSettingService)
        {
            _siteSettingService = siteSettingService;
        }
        [BindProperty]
        public PortalBuilder.Models.SiteSetting SiteSetting { get; set; }
        public void OnGet(int id)
        {
            var groups = _siteSettingService.GetColorForManage();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text");

            SiteSetting = _siteSettingService.GetSiteSettingById(id);

        }

        public IActionResult OnPost(IFormFile imgCourseUp)
        {
            if (!ModelState.IsValid)
                return Page();

            _siteSettingService.UpdateSiteSetting(SiteSetting, imgCourseUp);

            return Redirect("/Admin");
        }
    }
}
