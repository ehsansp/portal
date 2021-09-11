using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortalBuilder.Core.DTOs.Article;
using PortalBuilder.Core.DTOs.Province;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services
{
   public  class ProvinceService:IProvinceService
   {
       private ShahrContext _context;

       public ProvinceService(ShahrContext context)
       {
           _context = context;
       }
        public List<ShowProvinceForAdminViewModel> GetProvinceForAdmin()
        {
            return _context.Provinces.Select(c => new ShowProvinceForAdminViewModel()
            {
                Title = c.Title,
                EnTitle = c.EnTitle,
                Id = c.Id,
                SortIndex = c.SortIndex
            }).ToList();
        }

        public int AddProvince(Province province)
        {
            _context.Add(province);
            _context.SaveChanges();
            return province.Id;
        }

        public Province GetProvinceById(int provinceId)
        {
            return _context.Provinces.Find(provinceId);
        }

        public int UpdateProvince(Province province)
        {
            _context.Provinces.Update(province);
            _context.SaveChanges();
            return province.Id;
        }
   }
}
