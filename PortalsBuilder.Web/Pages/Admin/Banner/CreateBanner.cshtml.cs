using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Banner
{
    public class CreateBannerModel : PageModel
    {
        private IBannerService _bannerService;

        public CreateBannerModel(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }
        [BindProperty]
        public PortalBuilder.Models.Banner Banner { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _bannerService.AddBanner(Banner);

            return RedirectToPage("Index");
        }
    }
}
