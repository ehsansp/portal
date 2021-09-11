using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.DTOs.Province;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Province
{
    public class IndexModel : PageModel
    {
        private IProvinceService _provinceService;

        public IndexModel(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        public List<ShowProvinceForAdminViewModel> ListProvince { get; set; }
        public void OnGet()
        {
            ListProvince = _provinceService.GetProvinceForAdmin();
        }
    }
}
