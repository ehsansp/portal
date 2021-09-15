using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.Models;

namespace PortalsBuilder.Web.Pages.Admin.Menu
{
    public class EditModel : PageModel
    {
        private IMenuService _menuService;

        public EditModel(IMenuService menuService)
        {
            _menuService = menuService;
        }
        [BindProperty]
        public PortalBuilder.Models.Menu Menu { get; set; }
        public void OnGet(int id)
        {
            var groups = _menuService.GetGroupForManageArticle();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text");
            Menu = _menuService.getMenuByIdMenu(id);
        }

        public IActionResult OnPost(bool rr)
        {
            if (!ModelState.IsValid)
                return Page();
            if (rr)
                Menu.ParentId = null;
            _menuService.UpdateMenu(Menu);

            return RedirectToPage("Index");
        }
    }
}
