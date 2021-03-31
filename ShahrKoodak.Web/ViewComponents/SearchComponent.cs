using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShahrKoodak.Core.Services.Interfaces;

namespace ShahrKoodak.Web.ViewComponents
{
    public class SearchComponent:ViewComponent
    {
        private IProductService _productService;

        public SearchComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var group = _productService.GetGroupForManageProduct();
            ViewData["group"] = new SelectList(group, "Value", "Text");

            

            var sub = _productService.GetSubGroupForManageCourse(int.Parse(group.First().Value));
            ViewData["sub"] = new SelectList(sub, "Value", "Text");
            return await Task.FromResult((IViewComponentResult)View("Search"));
        }
    }
}
