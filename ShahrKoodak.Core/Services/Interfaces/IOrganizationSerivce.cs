using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalBuilder.Core.DTOs.OrganizationUnit;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IOrganizationSerivce
    {
        List<ShowOrganizationUnitForAdminViewModel> getOrganizationForAdminViewModels();
        int AddOrganization(OrganizationUnit organization);
        OrganizationUnit GetOrganizationById(int organizationId);
        int UpdateOrganization(OrganizationUnit organization);
        List<SelectListItem> getOrganizationItems();
    }
}
