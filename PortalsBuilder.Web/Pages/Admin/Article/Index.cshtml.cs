using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.DTOs.Article;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Article
{
    public class IndexModel : PageModel
    {
        private IArticleService _articleService;

        public IndexModel(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public List<ShowArticleForAdminViewModel> ListArticle { get; set; }
        public void OnGet()
        {
            ListArticle = _articleService.GetArticlesForAdmin();
        }
    }
}
