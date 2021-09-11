using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.Convertors;
using PortalBuilder.Core.DTOs.Brand;
using PortalBuilder.Core.Generator;
using PortalBuilder.Core.Security;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services
{
    public class BrandService:IBrandService
    {
        private ShahrContext _context;

        public BrandService(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowBrandForAdminViewModel> GetBrandsForAdmin()
        {
            return _context.BrandTimelines.Select(c => new ShowBrandForAdminViewModel()
            {
                Title = c.Title,
                Photo = c.Photo,
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                IsActive = c.IsActive,
                Link = c.Link
            }).ToList();
        }

        public int AddBrand(BrandTimeline brand, IFormFile imgBank)
        {
            brand.Photo = "no-photo.jpg";
            //ToDo Check Image

            if (imgBank != null && imgBank.IsImage())
            {
                brand.Photo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgBank.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", brand.Photo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgBank.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", brand.Photo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }

            brand.CreatedAt=DateTime.Now;
            _context.Add(brand);
            _context.SaveChanges();
            return brand.Id;
        }

        public BrandTimeline GetBrandById(int brandId)
        {
            return _context.BrandTimelines.Find(brandId);
        }

        public int UpdateBrand(BrandTimeline brand, IFormFile imgArticle)
        {
            if (imgArticle != null && imgArticle.IsImage())
            {

                brand.Photo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgArticle.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", brand.Photo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgArticle.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", brand.Photo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }

            _context.BrandTimelines.Update(brand);
            _context.SaveChanges();
            return brand.Id;
        }
    }
}
