using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.DTOs.LandingPage;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface ILandingPageService
    {
        List<ShowLandingPageForAdminViewModel> getLandingPageForAdminViewModels();
        int AddLandingPage(LandingPage landing, IFormFile imgBank);
        LandingPage GetLandingById(int landingPageId);
        int UpdateLandingPage(LandingPage landing, IFormFile imgArticle);
    }
}
