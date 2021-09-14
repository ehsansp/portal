using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.DTOs.Staff;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Staff
{
    public class IndexModel : PageModel
    {
        private IStaffService _staffService;

        public IndexModel(IStaffService staffService)
        {
            _staffService = staffService;
        }
        public List<ShowStaffForAdminViewModel> ListStaff { get; set; }
        public void OnGet()
        {
            ListStaff = _staffService.getStaffForAdminViewModels();
        }
    }
}
