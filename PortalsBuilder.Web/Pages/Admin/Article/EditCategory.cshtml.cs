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
    public class EditCategoryModel : PageModel
    {
        private IArticleService _articleService;

        public EditCategoryModel(IArticleService articleService)
        {
            _articleService = articleService;
        }
        [BindProperty]
        public ArticleCategory ArticleCategory { get; set; }
        public void OnGet(int id)
        {
            ArticleCategory = _articleService.GetById(id);
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _articleService.UpdateGroup(ArticleCategory);

            return RedirectToPage("ArticleCategory");
        }
    }
}
