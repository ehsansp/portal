using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalBuilder.Core.DTOs.Menu;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IMenuService
    {
        List<ShowMenuForAdminVieWModel> getMenuForAdminViewModels();
        int AddMenuPage(Menu menu);
        Menu getMenuByIdMenu(int menuId);
        int UpdateMenu(Menu menu);
        List<SelectListItem> GetGroupForManageArticle();
    }
}
