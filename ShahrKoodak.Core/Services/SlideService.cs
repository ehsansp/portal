using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.Convertors;
using PortalBuilder.Core.DTOs.Slide;
using PortalBuilder.Core.Generator;
using PortalBuilder.Core.Security;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services
{
    public class SlideService: ISlideService
    {
        private ShahrContext _context;

        public SlideService(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowSlideForeAdminVierwModel> getSlideForAdminViewModels()
        {
            return _context.Slides.Select(c => new ShowSlideForeAdminVierwModel()
            {
                ClickCount = c.ClickCount,
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                Title = c.Title,
                IsActive = c.IsActive,
                Photo = c.Photo,
                SortIndex = c.SortIndex
            }).ToList();
        }

        public int AddSlide(Slide slide, IFormFile imgBank)
        {
            slide.Photo = "no-photo.jpg";
            //ToDo Check Image

            if (imgBank != null && imgBank.IsImage())
            {
                slide.Photo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgBank.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", slide.Photo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgBank.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", slide.Photo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }


            _context.Add(slide);
            _context.SaveChanges();
            return slide.Id;
        }

        public Slide GetSlideById(int slideId)
        {
            return _context.Slides.Find(slideId);
        }

        public int UpdateSlide(Slide slide, IFormFile imgArticle)
        {
            if (imgArticle != null && imgArticle.IsImage())
            {

                slide.Photo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgArticle.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", slide.Photo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgArticle.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", slide.Photo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }

            _context.Slides.Update(slide);
            _context.SaveChanges();
            return slide.Id;
        }
    }
}
