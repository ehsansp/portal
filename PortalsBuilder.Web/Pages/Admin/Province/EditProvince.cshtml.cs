using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Province
{
    public class EditProvinceModel : PageModel
    {
        private IProvinceService _provinceService;

        public EditProvinceModel(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        [BindProperty]
        public PortalBuilder.Models.Province Province { get; set; }
        public void OnGet(int id)
        {
            Province = _provinceService.GetProvinceById(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _provinceService.UpdateProvince(Province);

            return RedirectToPage("Index");
        }
    }
}
