using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.Models;

namespace PortalsBuilder.Web.Pages.Admin.Article
{
    public class ArticleCategoryModel : PageModel
    {
        private IArticleService _articleService;

        public ArticleCategoryModel(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public List<ArticleCategory> ArticleCategories { get; set; }
        public void OnGet()
        {
            ArticleCategories = _articleService.GetCategoryArticlesForAdmin();
        }
    }
}
