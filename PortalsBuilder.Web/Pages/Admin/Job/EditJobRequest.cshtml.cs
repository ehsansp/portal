using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.Models;

namespace PortalsBuilder.Web.Pages.Admin.Job
{
    public class EditJobRequestModel : PageModel
    {
        private IJobServicve _jobServicve;

        public EditJobRequestModel(IJobServicve jobServicve)
        {
            _jobServicve = jobServicve;
        }
        [BindProperty]
        public JobAdRequest JobAd { get; set; }
        public void OnGet(int id)
        {
            var groups = _jobServicve.GetJobForManage();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text");

            JobAd = _jobServicve.GetJobAdRequestById(id);
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _jobServicve.UpdateJobRequest(JobAd);

            return RedirectToPage("JobRequest");
        }
    }
}
