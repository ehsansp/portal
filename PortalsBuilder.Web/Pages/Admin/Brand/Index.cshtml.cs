using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.DTOs.Brand;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Brand
{
    public class IndexModel : PageModel
    {
        private IBrandService _brandService;

        public IndexModel(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public List<ShowBrandForAdminViewModel> ListBrand { get; set; }
        public void OnGet()
        {
            ListBrand = _brandService.GetBrandsForAdmin();
        }
    }
}
