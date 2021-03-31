using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShahrKoodak.Core.Services.Interfaces;

namespace ShahrKoodak.Web.ViewComponents
{
    public class DashboardComponent:ViewComponent
    {
        private IUserService _userService;

        public DashboardComponent(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            return await Task.FromResult((IViewComponentResult)View("Dashboard",
                _userService.GetUserInformation(User.Identity.Name)));
        }
    }
}
