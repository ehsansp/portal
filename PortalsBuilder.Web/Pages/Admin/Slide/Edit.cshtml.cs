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
    public class EditModel : PageModel
    {
        private ISlideService _slideService;

        public EditModel(ISlideService slideService)
        {
            _slideService = slideService;
        }
        [BindProperty]
        public PortalBuilder.Models.Slide Slide { get; set; }
        public void OnGet(int id)
        {
            Slide = _slideService.GetSlideById(id);

        }

        public IActionResult OnPost(IFormFile imgCourseUp)
        {
            if (!ModelState.IsValid)
                return Page();

            _slideService.UpdateSlide(Slide, imgCourseUp);

            return RedirectToPage("Index");
        }
    }
}
