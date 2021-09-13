using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.Convertors;
using PortalBuilder.Core.DTOs.LandingPage;
using PortalBuilder.Core.Generator;
using PortalBuilder.Core.Security;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services
{
    public class LandingPageService: ILandingPageService
    {
        private ShahrContext _context;

        public LandingPageService(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowLandingPageForAdminViewModel> getLandingPageForAdminViewModels()
        {
            return _context.LandingPages.Select(c => new ShowLandingPageForAdminViewModel()
            {
                ClickCount = c.ClickCount,
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                Title = c.Title,
                IsActive = c.IsActive,
                Photo = c.Photo,
                RouteTitle = c.RouteTitle
            }).ToList();
        }

        public int AddLandingPage(LandingPage landing, IFormFile imgBank)
        {
            landing.Photo = "no-photo.jpg";
            //ToDo Check Image

            if (imgBank != null && imgBank.IsImage())
            {
                landing.Photo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgBank.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", landing.Photo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgBank.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", landing.Photo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }

            
            _context.Add(landing);
            _context.SaveChanges();
            return landing.Id;
        }

        public LandingPage GetLandingById(int landingPageId)
        {
            return _context.LandingPages.Find(landingPageId);
        }

        public int UpdateLandingPage(LandingPage landing, IFormFile imgArticle)
        {
            if (imgArticle != null && imgArticle.IsImage())
            {

                landing.Photo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgArticle.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", landing.Photo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgArticle.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", landing.Photo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }

            _context.LandingPages.Update(landing);
            _context.SaveChanges();
            return landing.Id;
        }
    }
}
