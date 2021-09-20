using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalBuilder.Core.Convertors;
using PortalBuilder.Core.DTOs.SiteSetting;
using PortalBuilder.Core.Generator;
using PortalBuilder.Core.Security;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services
{
    public class SiteSettingService: ISiteSettingService
    {
        private ShahrContext _context;

        public SiteSettingService(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowSiteSettingForAdminViewModel> getSiteSettingForAdminViewModels()
        {
            return _context.SiteSettings.Select(c => new ShowSiteSettingForAdminViewModel()
            {
                BrandDescription = c.BrandDescription,
                BrandName = c.BrandName,
                BrandSlogan = c.BrandSlogan,
                FavIcon = c.FavIcon,
                LogoPhoto = c.LogoPhoto
            }).ToList();
        }

        public int AddSiteSetting(SiteSetting siteSetting, IFormFile imgBank)
        {
            siteSetting.LogoPhoto = "no-photo.jpg";
            //ToDo Check Image

            if (imgBank != null && imgBank.IsImage())
            {
                siteSetting.LogoPhoto = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgBank.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", siteSetting.LogoPhoto);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgBank.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", siteSetting.LogoPhoto);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }


            _context.Add(siteSetting);
            _context.SaveChanges();
            return 1;
        }

        public SiteSetting GetSiteSettingById(int siteSettingById)
        {
            return _context.SiteSettings.Find(siteSettingById);
        }

        public int UpdateSiteSetting(SiteSetting siteSetting, IFormFile imgArticle)
        {
            if (imgArticle != null && imgArticle.IsImage())
            {

                siteSetting.LogoPhoto = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgArticle.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", siteSetting.LogoPhoto);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgArticle.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", siteSetting.LogoPhoto);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }

            _context.SiteSettings.Update(siteSetting);
            _context.SaveChanges();
            return 1;
        }

        public List<SelectListItem> GetColorForManage()
        {
            return _context.ColorSites
                .Select(g => new SelectListItem()
                {
                    Text = g.Name,
                    Value = g.ColorId.ToString()
                }).ToList();
        }
    }
}
