using PortalBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalsBuilder.Web.Models
{
    public class siteSettingMenuBannerBrandTimelineVM
    {
        public siteSettingMenuBannerBrandTimelineVM()
        {
            banner = new List<Banner>();
            brandTimeline = new List<BrandTimeline>();
            branch = new List<Branch>();
            menu = new List<Menu>();
        }
        public SiteSetting siteSetting { get; set; }
        //public Menu menu { get; set; }
        public List<Banner> banner { get; set; }
        public List<BrandTimeline> brandTimeline { get; set; }
        public List<Branch> branch { get; set; }
        public List<Menu> menu { get; set; }
    }
}
