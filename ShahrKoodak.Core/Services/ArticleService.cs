using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PortalBuilder.Core.DTOs.Article;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;

namespace PortalBuilder.Core.Services
{
    public class ArticleService : IArticleService
    {
        private ShahrContext _context;

        public ArticleService(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowArticleForAdminViewModel> GetArticlesForAdmin()
        {
            return _context.Articles.Include(c=>c.ArticleCategory).Select(c => new ShowArticleForAdminViewModel()
            {
                ArticleCategoryTitle = c.ArticleCategory.Title,
                Title = c.Title,
                ArticleCategoryId = c.ArticleCategoryId,
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                IsActive = c.IsActive,
                ViewCount = c.ViewCount
            }).ToList();
        }
    }
}
