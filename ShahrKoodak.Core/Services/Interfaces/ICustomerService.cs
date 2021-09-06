using System;
using System.Collections.Generic;
using System.Text;
using PortalBuilder.Core.DTOs.Customer;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface ICustomerService
    {
        List<ShowCustomerForWebSiteViewModel> GetCustomerForWebSite();
    }
}
