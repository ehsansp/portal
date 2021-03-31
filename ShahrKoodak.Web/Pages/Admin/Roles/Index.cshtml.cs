using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShahrKoodak.Core.Security;
using ShahrKoodak.Core.Services.Interfaces;
using ShahrKoodak.DataLayer.Entities.User;

namespace ShahrKoodak.Web.Pages.Admin.Roles
{
    [PermissionChecker(6)]
    public class IndexModel : PageModel
    {
        private IPermissionService _permissionService;

        public IndexModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public List<Role> RolesList { get; set; }

        public void OnGet()
        {
            RolesList = _permissionService.GetRole();
        }




    }
}