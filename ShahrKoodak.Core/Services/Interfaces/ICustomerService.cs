using System;
using System.Collections.Generic;
using System.Text;
using PortalBuilder.Core.DTOs.Customer;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface ICustomerService
    {
        List<ShowCustomerForWebSiteViewModel> GetCustomerForWebSite();
        List<ShowCustomerForAdminViewModel> GetCustomerForAdmin();
        int AddCustomer(Customer customer);
        Customer GetCustomerById(int customerId);
        int UpdateCustomer(Customer customer);
    }
}
