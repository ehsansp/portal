using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.DTOs.Slide;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface ISlideService
    {
        List<ShowSlideForeAdminVierwModel> getSlideForAdminViewModels();
        int AddSlide(Slide slide, IFormFile imgBank);
        Slide GetSlideById(int slideId);
        int UpdateSlide(Slide slide, IFormFile imgArticle);
    }
}
