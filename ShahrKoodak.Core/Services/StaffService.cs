using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalBuilder.Core.Convertors;
using PortalBuilder.Core.DTOs.Staff;
using PortalBuilder.Core.Generator;
using PortalBuilder.Core.Security;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services
{
    public class StaffService : IStaffService
    {
        private ShahrContext _context;

        public StaffService(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowStaffForWebSiteViewModel> GetStaffForWebSite()
        {
            return _context.Staves.Include(c=>c.StaffPosition).Include(c=>c.OrganizationUnit).Select(c => new ShowStaffForWebSiteViewModel()
            {
                Education = c.Education,
                FirstName = c.FirstName,
                Id = c.Id,
                StaffPosition = c.StaffPosition.Title,
                OrganizationUnit = c.OrganizationUnit.Title,
                LastName = c.LastName,
                Phone = c.Phone,
                Photo = c.Photo
            }).ToList();
        }

        public List<ShowStaffForAdminViewModel> getStaffForAdminViewModels()
        {
            return _context.Staves.Select(c => new ShowStaffForAdminViewModel()
            {
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                IsActive = c.IsActive,
                Photo = c.Photo,
                SortIndex = c.SortIndex,
                FirstName = c.FirstName,
                LastName = c.LastName
            }).ToList();
        }

        public List<ShowStaffPositionForAdminViewModel> getStaffPositionForAdminViewModels()
        {
            return _context.StaffPositions.Select(c => new ShowStaffPositionForAdminViewModel()
            {
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                IsActive = c.IsActive,
                SortIndex = c.SortIndex,
                Title = c.Title
            }).ToList();
        }

        public int AddStaff(Staff staff, IFormFile imgBank)
        {
            staff.Photo = "no-photo.jpg";
            //ToDo Check Image

            if (imgBank != null && imgBank.IsImage())
            {
                staff.Photo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgBank.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", staff.Photo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgBank.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", staff.Photo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }

            staff.CreatedAt=DateTime.Now;
            _context.Add(staff);
            _context.SaveChanges();
            return staff.Id;
        }

        public int AddStaffPosition(StaffPosition staffPosition)
        {
            staffPosition.CreatedAt = DateTime.Now;
            _context.Add(staffPosition);
            _context.SaveChanges();
            return staffPosition.Id;
        }

        public Staff GetStaffId(int staffId)
        {
            return _context.Staves.Find(staffId);
        }

        public StaffPosition GetStaffPositionById(int staffPositionId)
        {
            return _context.StaffPositions.Find(staffPositionId);
        }

        public int UpdateStaff(Staff staff, IFormFile imgArticle)
        {
            if (imgArticle != null && imgArticle.IsImage())
            {

                staff.Photo = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgArticle.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/image", staff.Photo);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgArticle.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/article/thumb", staff.Photo);

                imgResizer.Image_resize(imagePath, thumbPath, 185);
            }
            
            _context.Staves.Update(staff);
            _context.SaveChanges();
            return staff.Id;
        }

        public int UpdateStaffPosition(StaffPosition staffPosition)
        {
            _context.StaffPositions.Update(staffPosition);
            _context.SaveChanges();
            return staffPosition.Id;
        }

        public List<SelectListItem> getStaffPositionItems()
        {
            return _context.StaffPositions
                .Select(g => new SelectListItem()
                {
                    Text = g.Title,
                    Value = g.Id.ToString()
                }).ToList();
        }

        public Customer LoginUser(LoginViewModel login)
        {
            string hashPasword = PasswordHelper.EncodePasswordMd5(login.Password);
            string email = FixedText.FixEmail(login.Email);
            return _context.Customers.SingleOrDefault(u => u.Phone == email && u.EncryptedPassword == hashPasword);
        }

        public Customer GetUserByActiveCode(string activeCode)
        {
            return _context.Customers.SingleOrDefault(u => u.ActiveCode == activeCode);
        }

        public bool IsExistUserName(string userName)
        {
            return _context.Customers.Any(u => u.Username == userName);
        }

        public int AddUser(Customer user)
        {
            _context.Customers.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public bool ActiveAcount(string activeCode)
        {
            var user = _context.Customers.SingleOrDefault((u => u.ActiveCode == activeCode));
            if (user == null || user.IsActive)
            {
                user.ActiveCode = NameGenerator.GenerateUniqeCode();
                _context.SaveChanges();
                return true;
            }

            _context.SaveChanges();
            user.IsActive = true;
            user.ActiveCode = NameGenerator.GenerateUniqeCode();
            _context.SaveChanges();
            return true;
        }

        public Customer GetUserByUserName(string username)
        {
            return _context.Customers.SingleOrDefault(u => u.Username == username);
        }

        public void ChangeUserPassword(string userName, string newPassword)
        {
            var user = GetUserByUserName(userName);
            user.EncryptedPassword = PasswordHelper.EncodePasswordMd5(newPassword);
           
        }
    }
}
