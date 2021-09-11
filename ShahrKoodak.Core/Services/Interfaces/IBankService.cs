using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.DTOs.Bank;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IBankService
    {
        List<ShowBankForAdminViewModel> GetBanksForAdmin();
        List<ShowDepositForAdminViewModel> GetDipositsForAdmin();
        int AddBank(Bank bank, IFormFile imgBank);
        int AddDeposit(BankDepositRequest bankDepositRequest);
        Bank GetBankById(int bankId);
        int UpdateBank(Bank bank,IFormFile imgArticle);
    }
}
