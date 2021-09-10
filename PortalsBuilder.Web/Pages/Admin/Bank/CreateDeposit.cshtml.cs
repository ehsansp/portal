using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Bank
{
    public class CreateDepositModel : PageModel
    {
        private IBankService _bankService;

        public CreateDepositModel(IBankService bankService)
        {
            _bankService = bankService;
        }
        [BindProperty]
        public PortalBuilder.Models.BankDepositRequest BankDepositRequest { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _bankService.AddDeposit(BankDepositRequest);

            return RedirectToPage("Deposit");
        }

    }
}
