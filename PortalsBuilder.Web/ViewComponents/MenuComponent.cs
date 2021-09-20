using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PortalBuilder.Core.Services.generic;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.Models;

namespace PortalsBuilder.Web.ViewComponents
{
    public class MenuComponent: ViewComponent
    {
        private IMenuService _menuService;
        private readonly IGenericRepository<SiteSetting> siteSetting;
        private readonly IConfiguration configuration;

        public MenuComponent(IMenuService menuService, IGenericRepository<SiteSetting> siteSetting, IConfiguration Configuration)
        {
            _menuService = menuService;
            this.siteSetting = siteSetting;
            configuration = Configuration;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.logo = configuration.GetConnectionString("baseImageUrl") + siteSetting.GetAll().FirstOrDefault().LogoPhoto;

            return await Task.FromResult((IViewComponentResult)View("Menu", _menuService.getMenuForAdminViewModels()));
        }
    }
}
