using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalBuilder.Core.DTOs.Branch;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IBranchService
    {
        List<ShowBranchForAdminViewModel> GetBranchForAdmin();
        int AddBranch(Branch branch);
        List<SelectListItem> GetProvinceForManageBranch();
        Branch GetById(int branchId);
        int UpdateBranch(Branch branch);
        List<SelectListItem> getBrancsItems();
    }
}
