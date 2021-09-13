using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortalBuilder.Core.DTOs.Page;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services
{
    public class PageService: IPageService
    {
        private ShahrContext _context;

        public PageService(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowPageForAdminViewModel> getPagesForAdminViewModels()
        {
            return _context.Pages.Select(c => new ShowPageForAdminViewModel()
            {
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                IsActive = c.IsActive,
                Title = c.Title,
                ViewCount = c.ViewCount
            }).ToList();
        }

        public int AddPage(Page page)
        {
            page.CreatedAt=DateTime.Now;
            _context.Add(page);
            _context.SaveChanges();
            return page.Id;
        }

        public Page GetPageById(int pageId)
        {
            return _context.Pages.Find(pageId);
        }

        public int UpdatePage(Page page)
        {
            _context.Pages.Update(page);
            _context.SaveChanges();
            return page.Id;
        }
    }
}
