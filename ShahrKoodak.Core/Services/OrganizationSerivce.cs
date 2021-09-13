using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortalBuilder.Core.DTOs.OrganizationUnit;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services
{
   public  class OrganizationSerivce: IOrganizationSerivce
   {
       private ShahrContext _context;

       public OrganizationSerivce(ShahrContext context)
       {
           _context = context;
       }
        public List<ShowOrganizationUnitForAdminViewModel> getOrganizationForAdminViewModels()
        {
            return _context.OrganizationUnits.Select(c => new ShowOrganizationUnitForAdminViewModel()
            {
               CreatedAt = c.CreatedAt,
               CreatedBy = c.CreatedBy,
               Id = c.Id,
               IsActive = c.IsActive,
               SortIndex = c.SortIndex,
               Title = c.Title
            }).ToList();
        }

        public int AddOrganization(OrganizationUnit organization)
        {
            organization.CreatedAt=DateTime.Now;

            _context.Add(organization);
            _context.SaveChanges();
            return organization.Id;
        }

        public OrganizationUnit GetOrganizationById(int organizationId)
        {
            return _context.OrganizationUnits.Find(organizationId);
        }

        public int UpdateOrganization(OrganizationUnit organization)
        {
            _context.OrganizationUnits.Update(organization);
            _context.SaveChanges();
            return organization.Id;
        }
    }
}
