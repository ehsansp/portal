using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.Convertors;
using PortalBuilder.Core.DTOs.Photo;
using PortalBuilder.Core.Generator;
using PortalBuilder.Core.Security;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services
{
    public class PhotoService: IPhotoService
    {
        private ShahrContext _context;

        public PhotoService(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowPhotoForAdminViewModel> getPhotoForAdminViewModels()
        {
            return _context.Photos.Select(c => new ShowPhotoForAdminViewModel()
            {
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                IsActive = c.IsActive,
                SortIndex = c.SortIndex,
                Title = c.Title
            }).ToList();
        }

        public List<ShowPhotoGalleryForAdminViewModel> getPhotoGalleryForAdminViewModels()
        {
            return _context.PhotoGalleries.Select(c => new ShowPhotoGalleryForAdminViewModel()
            {
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                IsActive = c.IsActive,
                SortIndex = c.SortIndex,
                Title = c.Title,
                Photo = c.Photo
            }).ToList();
        }

        public int AddPhoto(Photo photo)
        {
            _context.Add(photo);
            _context.SaveChanges();
            return photo.Id;
        }

        public int AddGallery(PhotoGallery gallery, IFormFile imgBank)
        {
            gallery.Photo = "no-photo.jpg";
            //ToDo Check Image

            if (imgBank != null && imgBank.IsImage())
            {
                gallery.Photo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgBank.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", gallery.Photo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgBank.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", gallery.Photo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }


            _context.Add(gallery);
            _context.SaveChanges();
            return gallery.Id;
        }

        public Photo GetPhotoById(int photoId)
        {
            return _context.Photos.Find(photoId);
        }

        public PhotoGallery GetGalleryById(int galleryId)
        {
            return _context.PhotoGalleries.Find(galleryId);
        }

        public int UpdatePhoto(Photo photo)
        {
            _context.Photos.Update(photo);
            _context.SaveChanges();
            return photo.Id;
        }

        public int UpdateGallery(PhotoGallery gallery, IFormFile imgArticle)
        {
            if (imgArticle != null && imgArticle.IsImage())
            {
                gallery.Photo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgArticle.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", gallery.Photo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgArticle.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", gallery.Photo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }

            _context.PhotoGalleries.Update(gallery);
            _context.SaveChanges();
            return gallery.Id;
        }
    }
}
