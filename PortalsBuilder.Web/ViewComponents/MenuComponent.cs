using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortalBuilder.Core.Services.Interfaces;

namespace PortalsBuilder.Web.ViewComponents
{
    public class MenuComponent: ViewComponent
    {
        private IMenuService _menuService;

        public MenuComponent(IMenuService menuService)
        {
            _menuService = menuService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("Menu", _menuService.getMenuForAdminViewModels()));
        }
    }
}
