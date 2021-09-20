using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Education
{
    public class EditModel : PageModel
    {
        private IEducationService _educationService;

        public EditModel(IEducationService educationService)
        {
            _educationService = educationService;
        }
        [BindProperty]
        public PortalBuilder.Models.EducationLevel Education { get; set; }
        public void OnGet(int id)
        {
            Education = _educationService.GetEducationById(id);

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _educationService.UpdateEducation(Education);

            return RedirectToPage("Index");
        }
    }
}
