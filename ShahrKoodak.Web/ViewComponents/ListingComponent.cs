using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShahrKoodak.Core.Services;
using ShahrKoodak.Core.Services.Interfaces;
using ShahrKoodak.DataLayer.Entities.User;

namespace ShahrKoodak.Web.ViewComponents
{
    public class ListingComponent:ViewComponent
    {
        private IProductService _productService;

        public ListingComponent(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("Listing",
                _productService.GetProductByUserId(User.Identity.Name)));
        }
    }
}
