using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.Models;

namespace PortalsBuilder.Web.Pages.Admin.Brand
{
    public class CreateBrandModel : PageModel
    {
        private IBrandService _brandService;

        public CreateBrandModel(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [BindProperty]
        public BrandTimeline Brand { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(IFormFile imgCourseUp)
        {
            //if (!ModelState.IsValid)
            //    return Page();

            _brandService.AddBrand(Brand, imgCourseUp);

            return RedirectToPage("Index");
        }
    }
}
