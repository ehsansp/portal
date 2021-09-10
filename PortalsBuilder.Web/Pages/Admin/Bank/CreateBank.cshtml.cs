using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Bank
{
    public class CreateBankModel : PageModel
    {
        private IBankService _bankService;

        public CreateBankModel(IBankService bankService)
        {
            _bankService = bankService;
        }
        [BindProperty]
        public PortalBuilder.Models.Bank Bank { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(IFormFile imgCourseUp)
        {
            if (!ModelState.IsValid)
                return Page();

            _bankService.AddBank(Bank, imgCourseUp);

            return RedirectToPage("Index");
        }

    }
}
