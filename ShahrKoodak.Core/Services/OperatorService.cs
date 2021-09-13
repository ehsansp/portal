using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.Convertors;
using PortalBuilder.Core.DTOs.Operator;
using PortalBuilder.Core.Generator;
using PortalBuilder.Core.Security;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services
{
    public class OperatorService: IOperatorService
    {
        private ShahrContext _context;

        public OperatorService(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowOperatorForAdminViewModel> getOperatorForAdminViewModels()
        {
            return _context.Operators.Select(c => new ShowOperatorForAdminViewModel()
            {
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                FirstName = c.FirstName,
                Id = c.Id,
                IsActive = c.IsActive,
                Photo = c.Photo,
                LastName = c.LastName,
                Username = c.Username
            }).ToList();
        }

        public List<ShowOperatorRoleForAdminViewModel> getOperatorRoleForAdminViewModels()
        {
            return _context.OperatorRoles.Select(c => new ShowOperatorRoleForAdminViewModel()
            {
                Id = c.Id,
                IsActive = c.IsActive,
                SortIndex = c.SortIndex,
                SystemName = c.SystemName,
                Title = c.Title
            }).ToList();
        }

        public int AddOperator(Operator opOperator, IFormFile imgBank)
        {
            opOperator.Photo = "no-photo.jpg";
            //ToDo Check Image

            if (imgBank != null && imgBank.IsImage())
            {
                opOperator.Photo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgBank.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", opOperator.Photo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgBank.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", opOperator.Photo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }

            opOperator.CreatedAt=DateTime.Now;
            _context.Add(opOperator);
            _context.SaveChanges();
            return opOperator.Id;
        }

        public int AddOperatorRole(OperatorRole operatorRole)
        {
            _context.Add(operatorRole);
            _context.SaveChanges();
            return operatorRole.Id;
        }

        public Operator GetLandingById(int operatorId)
        {
            return _context.Operators.Find(operatorId);
        }

        public OperatorRole GetOperatorRoleById(int operatorRoleId)
        {
            return _context.OperatorRoles.Find(operatorRoleId);
        }

        public int UpdateOperator(Operator oOperator, IFormFile imgArticle)
        {
            if (imgArticle != null && imgArticle.IsImage())
            {

                oOperator.Photo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgArticle.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", oOperator.Photo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgArticle.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", oOperator.Photo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }

            _context.Operators.Update(oOperator);
            _context.SaveChanges();
            return oOperator.Id;
        }

        public int UpdateOperatorRole(OperatorRole operatorRole)
        {
            _context.OperatorRoles.Update(operatorRole);
            _context.SaveChanges();
            return operatorRole.Id;
        }
    }
}
