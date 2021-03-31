using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShahrKoodak.Core.Security;
using ShahrKoodak.Core.Services.Interfaces;

namespace ShahrKoodak.Web.Pages.Admin.ProductGroups
{
    [PermissionChecker(19)]

    public class DeleteModel : PageModel
    {
        private IProductService _productService;

        public DeleteModel(IProductService productService)
        {
            _productService = productService;
        }
        [BindProperty] public DataLayer.Entities.Product.ProductGroup ProductFeature { get; set; }
        public void OnGet(int id)
        {
            ProductFeature = _productService.GetGroupById(id);
        }

        public IActionResult OnPost(int id)
        {
            _productService.DeleteGroup(id);

            return RedirectToPage("Index");
        }
    }
}
