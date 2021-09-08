using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PortalBuilder.Core.DTOs.Bank;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;

namespace PortalBuilder.Core.Services
{
    public class BankService : IBankService
    {
        private ShahrContext _context;

        public BankService(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowBankForAdminViewModel> GetBanksForAdmin()
        {
            return _context.Banks.Select(c => new ShowBankForAdminViewModel()
            {
               Title = c.Title,
               BankId = c.BankId,
               EnTitle = c.EnTitle,
               Logo = c.Logo
            }).ToList();
        }
    }
}
