using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Slide
{
    public class CreateModel : PageModel
    {
        private ISlideService _slideService;

        public CreateModel(ISlideService slideService)
        {
            _slideService = slideService;
        }
        public PortalBuilder.Models.Slide Slide { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(IFormFile imgCourseUp)
        {
            if (!ModelState.IsValid)
                return Page();

            _slideService.AddSlide(Slide, imgCourseUp);

            return RedirectToPage("Index");
        }
    }
}
