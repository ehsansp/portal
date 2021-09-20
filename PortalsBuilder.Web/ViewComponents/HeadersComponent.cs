using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PortalBuilder.Core.Services.generic;
using PortalBuilder.Models;
using PortalsBuilder.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalsBuilder.Web.ViewComponents
{
    public class HeadersComponent : ViewComponent
    {
        private readonly IGenericRepository<Branch> _branch;
        private readonly IGenericRepository<Banner> _banner;
        private readonly IGenericRepository<SiteSetting> _siteSetting;
        private readonly IGenericRepository<BrandTimeline> _brandTimeline;
        private readonly IConfiguration configuration;
        public HeadersComponent(IConfiguration Configuration, IGenericRepository<Branch> branch,IGenericRepository<Banner> banner , IGenericRepository<SiteSetting> siteSetting, IGenericRepository<BrandTimeline> brandTimeline)
        {
            this._branch = branch;
            _banner = banner;
            _siteSetting = siteSetting;
            _brandTimeline = brandTimeline;
            Configuration = configuration;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var res = new siteSettingMenuBannerBrandTimelineVM();
            res.banner.AddRange(_banner.GetAll());
            res.brandTimeline.AddRange(_brandTimeline.GetAll());
            res.siteSetting = _siteSetting.GetAll().FirstOrDefault();
            res.branch.AddRange(_branch.GetAll());
            ViewBag.ImageUrl = configuration.GetConnectionString("baseImageUrl");
            return await Task.FromResult((IViewComponentResult)View("Headers", res));
        }
    }
}
