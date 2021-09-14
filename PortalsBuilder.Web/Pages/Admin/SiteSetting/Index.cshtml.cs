using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.DTOs.SiteSetting;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.SiteSetting
{
    public class IndexModel : PageModel
    {
        private ISiteSettingService _siteSettingService;

        public IndexModel(ISiteSettingService siteSettingService)
        {
            _siteSettingService = siteSettingService;
        }
        public List<ShowSiteSettingForAdminViewModel> ListSite { get; set; }
        public void OnGet()
        {
            ListSite = _siteSettingService.getSiteSettingForAdminViewModels();
        }
    }
}
