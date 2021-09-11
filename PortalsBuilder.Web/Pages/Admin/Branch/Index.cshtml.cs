using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.DTOs.Branch;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Branch
{
    public class IndexModel : PageModel
    {
        private IBranchService _branchService;

        public IndexModel(IBranchService branchService)
        {
            _branchService = branchService;
        }
        public List<ShowBranchForAdminViewModel> ListBranch { get; set; }
        public void OnGet()
        {
            ListBranch = _branchService.GetBranchForAdmin();
        }
    }
}
