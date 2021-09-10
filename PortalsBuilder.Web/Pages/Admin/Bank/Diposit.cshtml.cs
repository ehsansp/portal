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
    public class DipositModel : PageModel
    {
        private IBankService _bankService;

        public DipositModel(IBankService bankService)
        {
            _bankService = bankService;
        }
        public List<ShowDepositForAdminViewModel> ListDeposit { get; set; }
        public void OnGet()
        {
            ListDeposit = _bankService.GetDipositsForAdmin();
        }

        
    }
}
