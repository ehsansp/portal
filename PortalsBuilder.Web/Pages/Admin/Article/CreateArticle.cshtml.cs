using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Article
{
    public class CreateArticleModel : PageModel
    {
        private IArticleService _articleService;

        public CreateArticleModel(IArticleService articleService)
        {
            _articleService = articleService;
        }
        [BindProperty]
        public PortalBuilder.Models.Article Article { get; set; }
        public void OnGet()
        {
            var groups = _articleService.GetGroupForManageArticle();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text");
        }

        public IActionResult OnPost(IFormFile imgCourseUp)
        {
            if (!ModelState.IsValid)
                return Page();

            _articleService.AddArticle(Article, imgCourseUp);

            return RedirectToPage("Index");
        }
    }
}
