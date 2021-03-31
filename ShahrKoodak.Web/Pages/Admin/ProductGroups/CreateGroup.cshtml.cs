using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShahrKoodak.Core.Security;
using ShahrKoodak.Core.Services.Interfaces;
using ShahrKoodak.DataLayer.Entities.Product;

namespace ShahrKoodak.Web.Pages.Admin.ProductGroup
{
    [PermissionChecker(19)]

    public class CreateGroupModel : PageModel
    {
        private IProductService _productService;

        public CreateGroupModel(IProductService productService)
        {
            _productService = productService;
        }
        [BindProperty]
        public DataLayer.Entities.Product.ProductGroup ProductGroup { get; set; }
        public void OnGet(int? id)
        {
            ProductGroup = new DataLayer.Entities.Product.ProductGroup()
            {
                ParentId = id
            };
        }

        public IActionResult OnPost(IFormFile imgCourseUp)
        {
            if (!ModelState.IsValid)
                return Page();

            _productService.AddGroup(ProductGroup, imgCourseUp);

            return RedirectToPage("Index");
        }
    }
}