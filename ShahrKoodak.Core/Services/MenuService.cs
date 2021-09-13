using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortalBuilder.Core.DTOs.Menu;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services
{
   public  class MenuService: IMenuService
   {
       private ShahrContext _context;

       public MenuService(ShahrContext context)
       {
           _context = context;
       }
        public List<ShowMenuForAdminVieWModel> getMenuForAdminViewModels()
        {
            return _context.Menus.Select(c => new ShowMenuForAdminVieWModel()
            {
               CreatedAt = c.CreatedAt,
               CreatedBy = c.CreatedBy,
               Id = c.Id,
               IsActive = c.IsActive,
               SortIndex = c.SortIndex,
               Title = c.Title
            }).ToList();
        }

        public int AddMenuPage(Menu menu)
        {
            menu.CreatedAt=DateTime.Now;
            _context.Add(menu);
            _context.SaveChanges();
            return menu.Id;
        }

        public Menu getMenuByIdMenu(int menuId)
        {
            return _context.Menus.Find(menuId);
        }

        public int UpdateMenu(Menu menu)
        {
            _context.Menus.Update(menu);
            _context.SaveChanges();
            return menu.Id;
        }
    }
}
