using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PortalBuilder.DataLayer.Models;

namespace PortalBuilder.Models
{
    public class SiteSetting
    {
        [Key] 
        public int Id { get; set; }

        public int ColorId { get; set; }
        public string BrandName { get; set; }
        public string BrandDescription { get; set; }
        public string LogoPhoto { get; set; }
        public string FavIcon { get; set; }
        public string BrandSlogan { get; set; }
        public string BrandMission { get; set; }
        public string BrandVision { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public bool RedirectToUrl { get; set; }
        public string RedirectUrl { get; set; }
        public bool AllowSecondLanguage { get; set; }
        public string AdminAllowedIPs { get; set; }
        public string ActiveTheme { get; set; }
        public string HomePageMode { get; set; }
        public bool AllowCustomerRegisteration { get; set; }


        public ColorSite ColorSite { get; set; }
        
    }
}
