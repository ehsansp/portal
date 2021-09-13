using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortalBuilder.Core.DTOs.Partner;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services
{
    public class PartnerService: IPartnerService
    {
        private ShahrContext _context;

        public PartnerService(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowPartnerForAdminViewModel> getPartnerForAdminViewModels()
        {
            return _context.Partners.Select(c => new ShowPartnerForAdminViewModel()
            {
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                IsActive = c.IsActive,
                SortIndex = c.SortIndex,
                Title = c.Title
            }).ToList();
        }

        public int AddPartner(Partner partner)
        {
            partner.CreatedAt=DateTime.Now;

            _context.Add(partner);
            _context.SaveChanges();
            return partner.Id;
        }

        public Partner GetPartnerById(int partnerId)
        {
            return _context.Partners.Find(partnerId);
        }

        public int UpdatePartner(Partner partner)
        {
            _context.Partners.Update(partner);
            _context.SaveChanges();
            return partner.Id;
        }
    }
}
