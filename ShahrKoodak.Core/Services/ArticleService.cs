using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalBuilder.Core.Convertors;
using PortalBuilder.Core.DTOs.Article;
using PortalBuilder.Core.Generator;
using PortalBuilder.Core.Security;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

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
                Id = c.ArticleId,
                IsActive = c.IsActive,
                ViewCount = c.ViewCount
            }).ToList();
        }


        public int AddArticle(Article article, IFormFile imgArticle)
        {
            article.CreatedAt = DateTime.Now;
            article.Photo = "no-photo.jpg";
            //ToDo Check Image

            if (imgArticle != null && imgArticle.IsImage())
            {
                article.Photo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgArticle.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", article.Photo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgArticle.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", article.Photo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }

            _context.Add(article);
            _context.SaveChanges();
            return article.ArticleId;
        }
        public Article GetArticleById(int articleId)
        {
            return _context.Articles.Find(articleId);
        }

        public int AddGroup(ArticleCategory @group)
        {
            group.CreatedAt=DateTime.Now;

            _context.ArticleCategories.Add(group);
            _context.SaveChanges();
            return group.Id;
        }

        public ArticleCategory GetById(int groupId)
        {
            return _context.ArticleCategories.Find(groupId);
        }

        public int UpdateGroup(ArticleCategory @group)
        {
            _context.ArticleCategories.Update(group);
            _context.SaveChanges();
            return group.Id;
        }

        public List<SelectListItem> GetGroupForManageArticle()
        {
            return _context.ArticleCategories.Where(g => g.ParentId == null)
                .Select(g => new SelectListItem()
                {
                    Text = g.Title,
                    Value = g.Id.ToString()
                }).ToList();
        }

        public List<ArticleCategory> GetCategoryArticlesForAdmin()
        {
            return _context.ArticleCategories.Include(c => c.Parent).ToList();

        }
    }
}
