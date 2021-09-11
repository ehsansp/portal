using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.Convertors;
using PortalBuilder.Core.DTOs.Certificate;
using PortalBuilder.Core.Generator;
using PortalBuilder.Core.Security;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services
{
    public class CertificateService : ICertificateService
    {
        private ShahrContext _context;

        public CertificateService(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowCertificateForWebSiteViewModel> GetCertificateForAdmin()
        {
            return _context.Certificates.Select(c => new ShowCertificateForWebSiteViewModel()
            {
                Photo = c.Photo,
                Title = c.Title,
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                IsActive = c.IsActive,
                Link = c.Link,
                SortIndex = c.SortIndex
            }).ToList();
        }

        public int AddCertificate(Certificate certificate, IFormFile imgBank)
        {
            certificate.Photo = "no-photo.jpg";
            //ToDo Check Image

            if (imgBank != null && imgBank.IsImage())
            {
                certificate.Photo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgBank.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", certificate.Photo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgBank.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", certificate.Photo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }
            certificate.CreatedAt=DateTime.Now;
            certificate.CreatedBy = 1;

            _context.Add(certificate);
            _context.SaveChanges();
            return certificate.Id;
        }
    }
}
