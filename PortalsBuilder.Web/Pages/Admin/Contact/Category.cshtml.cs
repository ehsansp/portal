using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.DTOs.Contact;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.Models;

namespace PortalsBuilder.Web.Pages.Admin.Contact
{
    public class CategoryModel : PageModel
    {
        private IContactService _contactService;

        public CategoryModel(IContactService contactService)
        {
            _contactService = contactService;
        }
        public List<ShowContactCategoryForAdminViewModel> ContactMessageCategories { get; set; }
        public void OnGet()
        {
            ContactMessageCategories = _contactService.GetContactCategoryForAdmin();
        }
    }
}
