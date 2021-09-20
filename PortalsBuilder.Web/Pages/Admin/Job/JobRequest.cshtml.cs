using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.DTOs.Job;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Job
{
    public class JobRequestModel : PageModel
    {
        private IJobServicve _jobServicve;

        public JobRequestModel(IJobServicve jobServicve)
        {
            _jobServicve = jobServicve;
        }

        public List<ShowJobAdRequestForAdminViewModel> ListJob { get; set; }
        public void OnGet()
        {
            ListJob = _jobServicve.GetJobAdRequestsForAdmin();
        }
    }
}
