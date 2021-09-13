using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.DTOs.Product;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IProductService
    {
        List<ShowProductForAdminViewModel> getProductForAdminViewModels();
        int AddProduct(Product product, IFormFile imgBank);
        Product GetProductById(int productId);
        int UpdateProduct(Product product, IFormFile imgArticle);
    }
}
