using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Certificate
{
    public class CreateCertificateModel : PageModel
    {
        private ICertificateService _certificateService;

        public CreateCertificateModel(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }
        [BindProperty]
        public PortalBuilder.Models.Certificate Certificate { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(IFormFile imgCourseUp)
        {
            if (!ModelState.IsValid)
                return Page();

            _certificateService.AddCertificate(Certificate, imgCourseUp);

            return RedirectToPage("Index");
        }
    }
}
