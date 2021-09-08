using System;
using System.Collections.Generic;
using System.Text;
using PortalBuilder.Core.DTOs.Bank;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IBankService
    {
        List<ShowBankForAdminViewModel> GetBanksForAdmin();
    }
}
