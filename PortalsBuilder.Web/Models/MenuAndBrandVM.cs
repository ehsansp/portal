using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalsBuilder.Web.Models
{
    public class MenuAndBrandVM
    {
        public MenuAndBrandVM()
        {
            menuList = new List<PortalBuilder.Models.Menu>();
        }
        public List<PortalBuilder.Models.Menu> menuList { get; set; }
        public PortalBuilder.Models.SiteSetting SiteSetting { get; set; }
        public PortalBuilder.Models.Branch branch { get; set; }
    }
}
