using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Bank
{
    public class EditBankModel : PageModel
    {
        private IBankService _bankService;

        public EditBankModel(IBankService bankService)
        {
            _bankService = bankService;
        }

        [BindProperty]
        public PortalBuilder.Models.Bank Bank { get; set; }
        public void OnGet(int id)
        {
            Bank = _bankService.GetBankById(id);

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _bankService.UpdateBank(Bank);

            return RedirectToPage("Index");
        }
    }
}
