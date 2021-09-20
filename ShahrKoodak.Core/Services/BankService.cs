using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PortalBuilder.Core.Convertors;
using PortalBuilder.Core.DTOs.Bank;
using PortalBuilder.Core.Generator;
using PortalBuilder.Core.Security;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

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

        

        public List<ShowDepositForAdminViewModel> GetDipositsForAdmin()
        {
            return _context.BankDepositRequests.Include(c=>c.Bank).Select(c => new ShowDepositForAdminViewModel()
            {
                Amount = c.Amount,
                BankId = c.BankId,
                BankName = c.Bank.Title,
                BranchTitle = c.BranchTitle,
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.BankDepositId,
                NationalCode = c.NationalCode
            }).ToList();
        }

        public int AddBank(Bank bank, IFormFile imgBank)
        {
            bank.Logo = "no-photo.jpg";
            //ToDo Check Image

            if (imgBank != null && imgBank.IsImage())
            {
                bank.Logo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgBank.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", bank.Logo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgBank.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", bank.Logo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }

            _context.Add(bank);
            _context.SaveChanges();
            return bank.BankId;
        }

        public int AddDeposit(BankDepositRequest bankDepositRequest)
        {
            bankDepositRequest.CreatedAt=DateTime.Now;
            bankDepositRequest.CreatedBy = 1;
            _context.Add(bankDepositRequest);
            _context.SaveChanges();
            return bankDepositRequest.BankDepositId;
        }

        public Bank GetBankById(int bankId)
        {
            return _context.Banks.Find(bankId);
        }

        public int UpdateBank(Bank bank,IFormFile imgArticle)
        {
            if (imgArticle != null && imgArticle.IsImage())
            {
                
                bank.Logo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgArticle.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", bank.Logo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgArticle.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", bank.Logo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }

            _context.Banks.Update(bank);
            _context.SaveChanges();
            return bank.BankId;
        }
    }
}
