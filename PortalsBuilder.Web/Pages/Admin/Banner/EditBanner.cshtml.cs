using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Banner
{
    public class EditBannerModel : PageModel
    {
        private IBannerService _bannerService;

        public EditBannerModel(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }
        [BindProperty]
        public PortalBuilder.Models.Banner Banner { get; set; }
        public void OnGet(int id)
        {
            Banner = _bannerService.GetBannerById(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _bannerService.UpdateBanner(Banner);

            return RedirectToPage("Index");
        }
    }
}
