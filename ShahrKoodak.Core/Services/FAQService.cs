using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.Convertors;
using PortalBuilder.Core.DTOs.FAQ;
using PortalBuilder.Core.Generator;
using PortalBuilder.Core.Security;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services
{
    public class FAQService: IFAQService
    {
        private ShahrContext _context;

        public FAQService(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowFAQCategoryForAdminVieWModel> GetFAQCaregoriesForAdmin()
        {
            return _context.FaqCategories.Select(c => new ShowFAQCategoryForAdminVieWModel()
            {
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                IsActive = c.IsActive,
                SortIndex = c.SortIndex,
                Title = c.Title
            }).ToList();
        }

        public List<ShowFAQForAdminViewModel> GetFAQsForAdmin()
        {
            return _context.Faqs.Select(c => new ShowFAQForAdminViewModel()
            {
                Photo = c.Photo,
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                IsActive = c.IsActive,
                SortIndex = c.SortIndex,
                Answer = c.Answer,
                Question = c.Question
            }).ToList();
        }

        public int AddFAQ(FAQ faq, IFormFile imgBank)
        {
            faq.Photo = "no-photo.jpg";
            //ToDo Check Image

            if (imgBank != null && imgBank.IsImage())
            {
                faq.Photo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgBank.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", faq.Photo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgBank.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", faq.Photo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }

            faq.CreatedAt=DateTime.Now;
            _context.Add(faq);
            _context.SaveChanges();
            return faq.Id;
        }

        public int AddFAQCategory(FAQCategory faqCategory)
        {
            faqCategory.CreatedAt = DateTime.Now;
            _context.Add(faqCategory);
            _context.SaveChanges();
            return faqCategory.Id;
        }

        public FAQ GetFAQById(int faqId)
        {
            return _context.Faqs.Find(faqId);
        }

        public FAQCategory GetFaqCategoryById(int categoryId)
        {
            return _context.FaqCategories.Find(categoryId);
        }

        public int UpdateFAQ(FAQ faq, IFormFile imgArticle)
        {
            if (imgArticle != null && imgArticle.IsImage())
            {

                faq.Photo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgArticle.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", faq.Photo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgArticle.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", faq.Photo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }

            _context.Faqs.Update(faq);
            _context.SaveChanges();
            return faq.Id;
        }

        public int UpdateFAQCategory(FAQCategory faqCategory)
        {
            _context.FaqCategories.Update(faqCategory);
            _context.SaveChanges();
            return faqCategory.Id;
        }
    }
}
