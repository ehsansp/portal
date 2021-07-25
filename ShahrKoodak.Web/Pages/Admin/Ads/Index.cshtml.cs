using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShahrKoodak.Core.DTOs.Product;
using ShahrKoodak.Core.Security;
using ShahrKoodak.Core.Services.Interfaces;

namespace ShahrKoodak.Web.Pages.Admin.Ads
{
    [PermissionChecker(10)]
    public class IndexModel : PageModel
    {
        private IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }
        public List<ShowProductForAdminViewModel> ListProduct { get; set; }
        public void OnGet(string filterProduct = "", string filterProductGroup = "")
        {
            ListProduct = _productService.GetProductsForAdmin(filterProduct, filterProductGroup);
        }
    }
}
