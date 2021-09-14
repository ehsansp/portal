using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Staff
{
    public class EditPositionModel : PageModel
    {
        private IStaffService _staffService;

        public EditPositionModel(IStaffService staffService)
        {
            _staffService = staffService;
        }
        [BindProperty]
        public PortalBuilder.Models.StaffPosition Staff { get; set; }
        public void OnGet(int id)
        {
            

            Staff = _staffService.GetStaffPositionById(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _staffService.UpdateStaffPosition(Staff);

            return RedirectToPage("StaffPosition");
        }
    }
}
