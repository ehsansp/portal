using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.DTOs.Bank;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Bank
{
    public class IndexModel : PageModel
    {
        private IBankService _bankService;

        public IndexModel(IBankService bankService)
        {
            _bankService = bankService;
        }
        public List<ShowBankForAdminViewModel> ListBank { get; set; }
        public void OnGet()
        {
        }
    }
}
