using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Staff
{
    public class CreatePositionModel : PageModel
    {
        private IStaffService _staffService;

        public CreatePositionModel(IStaffService staffService)
        {
            _staffService = staffService;
        }
        [BindProperty]
        public PortalBuilder.Models.StaffPosition Staff { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _staffService.AddStaffPosition(Staff);

            return RedirectToPage("StaffPosition");
        }
    }
}
