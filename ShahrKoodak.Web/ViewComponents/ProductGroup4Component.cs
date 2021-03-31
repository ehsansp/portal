using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShahrKoodak.Core.Services.Interfaces;

namespace ShahrKoodak.Web.ViewComponents
{
    public class ProductGroup4Component:ViewComponent
    {
        private IProductService _productService;

        public ProductGroup4Component(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("ProductGroup4", _productService.GetAllGroup()));
        }
    }
}
