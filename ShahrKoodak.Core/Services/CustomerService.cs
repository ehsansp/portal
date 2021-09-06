using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortalBuilder.Core.DTOs.Customer;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;

namespace PortalBuilder.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private ShahrContext _context;

        public CustomerService(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowCustomerForWebSiteViewModel> GetCustomerForWebSite()
        {
            return _context.Customers.Select(c => new ShowCustomerForWebSiteViewModel()
            {
                Description = c.Description,
                FirstName = c.FirstName,
                Id = c.Id,
                JobTitle = c.JobTitle,
                LastName = c.LastName
            }).ToList();
        }
    }
}
