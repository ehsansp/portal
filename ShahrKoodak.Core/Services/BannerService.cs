using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PortalBuilder.Core.DTOs.Article;
using PortalBuilder.Core.DTOs.Banner;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services
{
    public class BannerService:IBannerService
    {
        private ShahrContext _context;

        public BannerService(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowBannerForAdminViewModel> GetBannersForAdmin()
        {
            return _context.Banners.Select(c => new ShowBannerForAdminViewModel()
            {
                Photo = c.Photo,
                ClickCount = c.ClickCount,
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                IsActive = c.IsActive,
                Title = c.Title
            }).ToList();
        }

        public int AddBanner(Banner banner)
        {
            banner.CreatedAt = DateTime.Now;

            _context.Add(banner);
            _context.SaveChanges();
            return banner.Id;
        }

        public Banner GetBannerById(int bannerId)
        {
            return _context.Banners.Find(bannerId);
        }

        public int UpdateBanner(Banner banner)
        {
            _context.Banners.Update(banner);
            _context.SaveChanges();
            return banner.Id;
        }
    }
}
