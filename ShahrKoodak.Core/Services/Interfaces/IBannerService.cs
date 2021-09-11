using System;
using System.Collections.Generic;
using System.Text;
using PortalBuilder.Core.DTOs.Banner;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IBannerService
    {
        List<ShowBannerForAdminViewModel> GetBannersForAdmin();
        int AddBanner(Banner banner);
        Banner GetBannerById(int bannerId);
        int UpdateBanner(Banner banner);
    }
}
