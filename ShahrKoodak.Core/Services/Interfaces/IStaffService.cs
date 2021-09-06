using System;
using System.Collections.Generic;
using System.Text;
using PortalBuilder.Core.DTOs.Staff;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IStaffService
    {
        List<ShowStaffForWebSiteViewModel> GetStaffForWebSite();
    }
}
