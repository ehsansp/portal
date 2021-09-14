using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalBuilder.Core.DTOs.Bank;
using PortalBuilder.Core.DTOs.Branch;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services
{
    public class BranchService:IBranchService
    {
        private ShahrContext _context;

        public BranchService(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowBranchForAdminViewModel> GetBranchForAdmin()
        {
            return _context.Branches.Select(c => new ShowBranchForAdminViewModel()
            {
                City = c.City,
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                ManagerName = c.ManagerName,
                Phone = c.Phone,
                Title = c.Title
            }).ToList();
        }

        public int AddBranch(Branch branch)
        {
            branch.CreatedAt=DateTime.Now;
            branch.CreatedBy = 1;
            _context.Add(branch);
            _context.SaveChanges();
            return branch.Id;
        }

        public List<SelectListItem> GetProvinceForManageBranch()
        {
            return _context.Provinces
                .Select(g => new SelectListItem()
                {
                    Text = g.Title,
                    Value = g.Id.ToString()
                }).ToList();
        }

        public Branch GetById(int branchId)
        {
            return _context.Branches.Find(branchId);
        }

        public int UpdateBranch(Branch branch)
        {
            _context.Branches.Update(branch);
            _context.SaveChanges();
            return branch.Id;
        }

        public List<SelectListItem> getBrancsItems()
        {
            return _context.Branches
                .Select(g => new SelectListItem()
                {
                    Text = g.Title,
                    Value = g.Id.ToString()
                }).ToList();
        }
    }
}
