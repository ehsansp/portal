using System;
using System.Collections.Generic;
using System.Text;
using PortalBuilder.Core.DTOs.Contact;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IContactService
    {
        List<ShowContactCategoryForAdminViewModel> GetContactCategoryForAdmin();
        int AddCategory(ContactMessageCategory contact);
        ContactMessageCategory GetCategoryById(int categoryId);
        int UpdateCategory(ContactMessageCategory category);
        List<ShowContactMessageForAdminViewModel> GetContactForAdmin();
        int AddContact(ContactMessage contact);
        ContactMessage GetContactById(int contactId);
        int UpdateContact(ContactMessage contact);
    }
}
