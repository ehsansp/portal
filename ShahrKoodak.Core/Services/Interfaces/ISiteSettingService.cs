using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.DTOs.SiteSetting;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface ISiteSettingService
    {
        List<ShowSiteSettingForAdminViewModel> getSiteSettingForAdminViewModels();
        int AddSiteSetting(SiteSetting siteSetting, IFormFile imgBank);
        SiteSetting GetSiteSettingById(int siteSettingById);
        int UpdateSiteSetting(SiteSetting siteSetting, IFormFile imgArticle);
    }
}
