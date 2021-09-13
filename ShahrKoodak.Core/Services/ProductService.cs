using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.Convertors;
using PortalBuilder.Core.DTOs.Product;
using PortalBuilder.Core.Generator;
using PortalBuilder.Core.Security;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services
{
    public class ProductService: IProductService
    {
        private ShahrContext _context;

        public ProductService(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowProductForAdminViewModel> getProductForAdminViewModels()
        {
            return _context.Products.Select(c => new ShowProductForAdminViewModel()
            {
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                Title = c.Title,
                IsActive = c.IsActive,
                Photo = c.Photo,
                RouteTitle = c.RouteTitle,
                SortIndex = c.SortIndex
            }).ToList();
        }

        public int AddProduct(Product product, IFormFile imgBank)
        {
            product.Photo = "no-photo.jpg";
            //ToDo Check Image

            if (imgBank != null && imgBank.IsImage())
            {
                product.Photo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgBank.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", product.Photo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgBank.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", product.Photo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }

            product.CreatedAt=DateTime.Now;
            _context.Add(product);
            _context.SaveChanges();
            return product.Id;
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.Find(productId);
        }

        public int UpdateProduct(Product product, IFormFile imgArticle)
        {
            if (imgArticle != null && imgArticle.IsImage())
            {

                product.Photo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgArticle.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", product.Photo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgArticle.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", product.Photo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }

            _context.Products.Update(product);
            _context.SaveChanges();
            return product.Id;
        }
    }
}
