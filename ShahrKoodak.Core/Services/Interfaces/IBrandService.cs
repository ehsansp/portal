using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.DTOs.Brand;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IBrandService
    {
        List<ShowBrandForAdminViewModel> GetBrandsForAdmin();
        int AddBrand(BrandTimeline brand, IFormFile imgBank);
        BrandTimeline GetBrandById(int brandId);
        int UpdateBrand(BrandTimeline brand, IFormFile imgArticle);
    }
}
