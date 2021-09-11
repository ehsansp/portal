using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Province
{
    public class CreateProvinceModel : PageModel
    {
        private IProvinceService _provinceService;

        public CreateProvinceModel(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }
        [BindProperty]
        public PortalBuilder.Models.Province Province { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _provinceService.AddProvince(Province);

            return RedirectToPage("Index");
        }
    }
}
