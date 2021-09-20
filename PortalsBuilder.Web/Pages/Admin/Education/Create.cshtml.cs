using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Education
{
    public class CreateModel : PageModel
    {
        private IEducationService _educationService;

        public CreateModel(IEducationService educationService)
        {
            _educationService = educationService;
        }
        public PortalBuilder.Models.EducationLevel Education { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _educationService.AddEducation(Education);

            return RedirectToPage("Index");
        }
    }
}
