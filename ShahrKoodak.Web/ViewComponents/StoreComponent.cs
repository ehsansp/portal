using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShahrKoodak.Core.Services.Interfaces;

namespace ShahrKoodak.Web.ViewComponents
{
    public class StoreComponent:ViewComponent
    {
        private IUserService _userService;
        private IProductService _productService;

        public StoreComponent(IUserService userService, IProductService productService)
        {
            _userService = userService;
            _productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var groups = _productService.GetGroupForManageProduct();
            ViewData["groups"] = new SelectList(groups, "Value", "Text");
            var subGroups = _productService.GetSubGroupForManageCourse(int.Parse(groups.First().Value));
            ViewData["subGroups"] = new SelectList(subGroups, "Value", "Text");
            return await Task.FromResult((IViewComponentResult)View("Store",
                _userService.GetStoreInformation(User.Identity.Name)));
        }
    }
}
