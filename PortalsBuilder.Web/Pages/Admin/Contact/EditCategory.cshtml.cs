using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.Models;

namespace PortalsBuilder.Web.Pages.Admin.Contact
{
    public class EditCategoryModel : PageModel
    {
        private IContactService _contactService;

        public EditCategoryModel(IContactService contactService)
        {
            _contactService = contactService;
        }

        [BindProperty]
        public ContactMessageCategory ContactMessageCategory { get; set; }
        public void OnGet(int id)
        {
            ContactMessageCategory = _contactService.GetCategoryById(id);

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _contactService.UpdateCategory(ContactMessageCategory);

            return RedirectToPage("Index");
        }
    }
}
