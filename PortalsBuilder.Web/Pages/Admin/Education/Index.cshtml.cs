using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.DTOs.EducationLevel;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Education
{
    public class IndexModel : PageModel
    {
        private IEducationService _educationService;

        public IndexModel(IEducationService educationService)
        {
            _educationService = educationService;
        }
        public List<ShowEducationLevelForAdminViewModel> ListEducation { get; set; }
        public void OnGet()
        {
            ListEducation = _educationService.GetEducationsForAdmin();
        }
    }
}
