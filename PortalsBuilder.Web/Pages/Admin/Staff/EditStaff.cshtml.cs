using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Staff
{
    public class EditStaffModel : PageModel
    {
        private IStaffService _staffService;
        private IBranchService _branchService;
        private IOrganizationSerivce _organizationSerivce;

        public EditStaffModel(IStaffService staffService, IBranchService branchService, IOrganizationSerivce organizationSerivce)
        {
            _staffService = staffService;
            _branchService = branchService;
            _organizationSerivce = organizationSerivce;
        }
        [BindProperty]
        public PortalBuilder.Models.Staff Staff { get; set; }
        public void OnGet(int id)
        {
            var groups = _branchService.getBrancsItems();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text");

            var groups2 = _organizationSerivce.getOrganizationItems();
            ViewData["Groups2"] = new SelectList(groups2, "Value", "Text");

            var groups3 = _staffService.getStaffPositionItems();
            ViewData["Groups3"] = new SelectList(groups3, "Value", "Text");

            Staff = _staffService.GetStaffId(id);
        }

        public IActionResult OnPost(IFormFile imgCourseUp)
        {
            if (!ModelState.IsValid)
                return Page();

            _staffService.UpdateStaff(Staff, imgCourseUp);

            return RedirectToPage("Index");
        }
    }
}
