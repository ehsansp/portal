using Microsoft.AspNetCore.Mvc;
using PortalBuilder.Core.Services.generic;
using PortalBuilder.Models;
using PortalsBuilder.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalsBuilder.Web.ViewComponents
{
    public class FootersComponent : ViewComponent
    {
        private readonly IGenericRepository<Menu> menu;
        private readonly IGenericRepository<Branch> _branch;
        private readonly IGenericRepository<Banner> _banner;
        private readonly IGenericRepository<SiteSetting> _siteSetting;
        private readonly IGenericRepository<BrandTimeline> _brandTimeline;
        public FootersComponent(IGenericRepository<Menu> menu, IGenericRepository<Branch> branch, IGenericRepository<Banner> banner, IGenericRepository<SiteSetting> siteSetting, IGenericRepository<BrandTimeline> brandTimeline)
        {
            this.menu = menu;
            this._branch = branch;
            _banner = banner;
            _siteSetting = siteSetting;
            _brandTimeline = brandTimeline;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var res = new siteSettingMenuBannerBrandTimelineVM();
            res.banner.AddRange(_banner.GetAll());
            res.brandTimeline.AddRange(_brandTimeline.GetAll());
            res.siteSetting = _siteSetting.GetAll().FirstOrDefault();
            res.branch.AddRange(_branch.GetAll());
            res.menu.AddRange(menu.GetAll());
            return await Task.FromResult((IViewComponentResult)View("Footers", res));
        }
    }
   
}

