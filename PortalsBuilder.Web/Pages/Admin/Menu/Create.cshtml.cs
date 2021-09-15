using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Menu
{
    public class CreateModel : PageModel
    {
        private IMenuService _menuService;

        public CreateModel(IMenuService menuService)
        {
            _menuService = menuService;
        }
        [BindProperty]
        public PortalBuilder.Models.Menu Menu { get; set; }
        public void OnGet()
        {
            var groups = _menuService.GetGroupForManageArticle();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text");
        }

        public IActionResult OnPost(bool rr)
        {
            if (!ModelState.IsValid)
                return Page();
            if (rr)
            {
                Menu.ParentId = null;
            }
            _menuService.AddMenuPage(Menu);

            return RedirectToPage("Index");
        }
    }
}
