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
    public class EditModel : PageModel
    {
        private IJobServicve _jobServicve;

        public EditModel(IJobServicve jobServicve)
        {
            _jobServicve = jobServicve;
        }
        [BindProperty]
        public JobAd JobAd { get; set; }
        public void OnGet(int id)
        {
            var groups = _jobServicve.GetProvinceForManageBranch();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text");

            var level = _jobServicve.GetEducationLevelForManageBranch();
            ViewData["level"] = new SelectList(level, "Value", "Text");

            JobAd = _jobServicve.GetJobAdById(id);
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _jobServicve.UpdateJob(JobAd);

            return RedirectToPage("Index");
        }
    }
}
