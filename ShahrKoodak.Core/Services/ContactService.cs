using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortalBuilder.Core.DTOs.Contact;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services
{
    public class ContactService : IContactService
    {
        private ShahrContext _context;

        public ContactService(ShahrContext context)
        {
            _context = context;
        }
        public List<ShowContactCategoryForAdminViewModel> GetContactCategoryForAdmin()
        {
            return _context.ContactMessageCategories.Select(c => new ShowContactCategoryForAdminViewModel()
            {
                Title = c.Title,
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.Id,
                IsActive = c.IsActive,
                SortIndex = c.SortIndex
            }).ToList();
        }

        public int AddCategory(ContactMessageCategory contact)
        {
            contact.CreatedAt = DateTime.Now;
            _context.Add(contact);
            _context.SaveChanges();
            return contact.Id;
        }

        public ContactMessageCategory GetCategoryById(int categoryId)
        {
            return _context.ContactMessageCategories.Find(categoryId);
        }

        public int UpdateCategory(ContactMessageCategory category)
        {
            _context.ContactMessageCategories.Update(category);
            _context.SaveChanges();
            return category.Id;
        }

        public List<ShowContactMessageForAdminViewModel> GetContactForAdmin()
        {
            return _context.ContactMessages.Select(c => new ShowContactMessageForAdminViewModel()
            {
                Title = c.Title,
                Cellphone = c.Cellphone,
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy,
                Id = c.CategoryId,
                NationalCode = c.NationalCode
            }).ToList();
        }

        public int AddContact(ContactMessage contact)
        {
            contact.CreatedAt = DateTime.Now;
            _context.Add(contact);
            _context.SaveChanges();
            return contact.Id;
        }

        public ContactMessage GetContactById(int contactId)
        {
            return _context.ContactMessages.Find(contactId);
        }

        public int UpdateContact(ContactMessage contact)
        {
            _context.ContactMessages.Update(contact);
            _context.SaveChanges();
            return contact.Id;
        }
    }
}
