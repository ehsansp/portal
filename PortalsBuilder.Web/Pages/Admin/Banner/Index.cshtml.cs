using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.DTOs.Banner;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Banner
{
    public class IndexModel : PageModel
    {
        private IBannerService _bannerService;

        public IndexModel(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }
        public List<ShowBannerForAdminViewModel> ListBanner { get; set; }
        public void OnGet()
        {
            ListBanner = _bannerService.GetBannersForAdmin();
        }
    }
}
