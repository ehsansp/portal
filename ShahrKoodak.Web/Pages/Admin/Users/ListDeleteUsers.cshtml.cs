using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShahrKoodak.Core.DTOs.User;
using ShahrKoodak.Core.Security;
using ShahrKoodak.Core.Services.Interfaces;

namespace ShahrKoodak.Web.Pages.Admin.Users
{
    [PermissionChecker(2)]

    public class ListDeleteUsersModel : PageModel
    {
        private IUserService _userService;

        public ListDeleteUsersModel(IUserService userService)
        {
            _userService = userService;
        }
        public UsersForAdminViewModel UsersForAdminViewModel { get; set; }

        public void OnGet(int pageId = 1, string filterEmail = "", string filterUserName = "")
        {
            UsersForAdminViewModel = _userService.GetDeleteUsers(pageId, filterEmail, filterUserName);
        }
    }
}