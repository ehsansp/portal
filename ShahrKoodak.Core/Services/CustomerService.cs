using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortalBuilder.Core.DTOs.Customer;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

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

        public List<ShowCustomerForAdminViewModel> GetCustomerForAdmin()
        {
            return _context.Customers.Select(c => new ShowCustomerForAdminViewModel()
            {
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                CreatedAt = c.CreatedAt,
                IsActive = c.IsActive,
                Phone = c.Phone,
                FirstName = c.FirstName,
                LastIP = c.LastIP,
                LastName = c.LastName,
                Username = c.Username
            }).ToList();
        }

        public int AddCustomer(Customer customer)
        {
            customer.CreatedAt=DateTime.Now;
            _context.Add(customer);
            _context.SaveChanges();
            return customer.Id;
        }

        public Customer GetCustomerById(int customerId)
        {
            return _context.Customers.Find(customerId);
        }

        public int UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return customer.Id;
        }
    }
}
