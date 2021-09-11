using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Branch
{
    public class CreateBranchModel : PageModel
    {
        private IBranchService _branchService;

        public CreateBranchModel(IBranchService branchService)
        {
            _branchService = branchService;
        }
        [BindProperty]
        public PortalBuilder.Models.Branch Branch { get; set; }
        public void OnGet()
        {
            var groups = _branchService.GetProvinceForManageBranch();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text");
        }
        public IActionResult OnPost()
        {
            //if (!ModelState.IsValid)
            //    return Page();

            _branchService.AddBranch(Branch);

            return RedirectToPage("Index");
        }
    }
}
