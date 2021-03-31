using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShahrKoodak.Core.Services.Interfaces;

namespace ShahrKoodak.Web.ViewComponents
{
    public class AccountDetailComponent : ViewComponent
    {
        private IUserService _userService;

        public AccountDetailComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var levels = _userService.GetCities();
            ViewData["City"] = new SelectList(levels, "Value", "Text");
            return await Task.FromResult((IViewComponentResult) View("AccountDetail",
                _userService.GetUserInformation(User.Identity.Name)));
        }

       
    }
}
