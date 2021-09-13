using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Customer
{
    public class CreateCustomerModel : PageModel
    {
        private ICustomerService _customerService;

        public CreateCustomerModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [BindProperty]
        public PortalBuilder.Models.Customer Customer { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            //if (!ModelState.IsValid)
            //    return Page();

            _customerService.AddCustomer(Customer);

            return RedirectToPage("Index");
        }
    }
}
