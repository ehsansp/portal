using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Article
{
    public class EditArticleModel : PageModel
    {
        private IArticleService _articleService;

        public EditArticleModel(IArticleService articleService)
        {
            _articleService = articleService;
        }
        [BindProperty]
        public PortalBuilder.Models.Article Article { get; set; }
        public void OnGet(int id)
        {
            var groups = _articleService.GetGroupForManageArticle();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text");
            Article = _articleService.GetArticleById(id);

        }
    }
}
