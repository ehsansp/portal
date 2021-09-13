using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.Convertors;
using PortalBuilder.Core.DTOs.Notification;
using PortalBuilder.Core.Generator;
using PortalBuilder.Core.Security;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services
{
    public class NotificationService: INotificationService
    {
        private ShahrContext _context;

        public NotificationService(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowNotificationForAdminViewModel> getNotificationForAdminViewModels()
        {
            return _context.Notifications.Select(c => new ShowNotificationForAdminViewModel()
            {
                ClickCount = c.ClickCount,
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                IsActive = c.IsActive,
                Photo = c.Photo,
                Title = c.LinkTitle
            }).ToList();
        }

        public int AddNotification(Notification notification, IFormFile imgBank)
        {
            notification.Photo = "no-photo.jpg";
            //ToDo Check Image

            if (imgBank != null && imgBank.IsImage())
            {
                notification.Photo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgBank.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", notification.Photo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgBank.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", notification.Photo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }

            
            _context.Add(notification);
            _context.SaveChanges();
            return notification.Id;
        }

        public Notification GetNotificationById(int notificationId)
        {
            return _context.Notifications.Find(notificationId);
        }

        public int UpdateNotification(Notification notification, IFormFile imgArticle)
        {
            if (imgArticle != null && imgArticle.IsImage())
            {

                notification.Photo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgArticle.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", notification.Photo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgArticle.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", notification.Photo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }

            _context.Notifications.Update(notification);
            _context.SaveChanges();
            return notification.Id;
        }
    }
}
