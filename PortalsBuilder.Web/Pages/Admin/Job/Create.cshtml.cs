using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Job
{
    public class CreateModel : PageModel
    {
        private IJobServicve _jobServicve;

        public CreateModel(IJobServicve jobServicve)
        {
            _jobServicve = jobServicve;
        }
        [BindProperty]
        public PortalBuilder.Models.JobAd JobAd { get; set; }
        public void OnGet()
        {
            var groups = _jobServicve.GetProvinceForManageBranch();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text");

            var level = _jobServicve.GetEducationLevelForManageBranch();
            ViewData["level"] = new SelectList(level, "Value", "Text");
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _jobServicve.AddJobAd(JobAd);

            return RedirectToPage("index");
        }
    }
}
