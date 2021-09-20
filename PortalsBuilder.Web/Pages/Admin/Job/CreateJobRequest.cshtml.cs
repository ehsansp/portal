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
    public class CreateJobRequestModel : PageModel
    {
        private IJobServicve _jobServicve;

        public CreateJobRequestModel(IJobServicve jobServicve)
        {
            _jobServicve = jobServicve;
        }
        [BindProperty]
        public PortalBuilder.Models.JobAdRequest JobAd { get; set; }
        public void OnGet()
        {
            var groups = _jobServicve.GetJobForManage();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text");
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _jobServicve.AddJobRequest(JobAd);

            return RedirectToPage("index");
        }
    }
}
