using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.DTOs.Menu;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.Pages.Admin.Menu
{
    public class IndexModel : PageModel
    {
        private IMenuService _menuService;

        public IndexModel(IMenuService menuService)
        {
            _menuService = menuService;
        }
        public List<ShowMenuForAdminVieWModel> ListMenu { get; set; }
        public void OnGet()
        {
            ListMenu = _menuService.getMenuForAdminViewModels();
        }
    }
}
