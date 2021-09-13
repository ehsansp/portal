using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.DTOs.Customer;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Customer
{
    public class IndexModel : PageModel
    {
        private ICustomerService _customerService;

        public IndexModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public List<ShowCustomerForAdminViewModel> ListCustomer { get; set; }
        public void OnGet()
        {
            ListCustomer = _customerService.GetCustomerForAdmin();
        }
    }
}
