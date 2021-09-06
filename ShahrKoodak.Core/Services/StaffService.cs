using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PortalBuilder.Core.DTOs.Staff;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;

namespace PortalBuilder.Core.Services
{
    public class StaffService : IStaffService
    {
        private ShahrContext _context;

        public StaffService(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowStaffForWebSiteViewModel> GetStaffForWebSite()
        {
            return _context.Staves.Include(c=>c.StaffPosition).Include(c=>c.OrganizationUnit).Select(c => new ShowStaffForWebSiteViewModel()
            {
                Education = c.Education,
                FirstName = c.FirstName,
                Id = c.Id,
                StaffPosition = c.StaffPosition.Title,
                OrganizationUnit = c.OrganizationUnit.Title,
                LastName = c.LastName,
                Phone = c.Phone,
                Photo = c.Photo
            }).ToList();
        }
    }
}
