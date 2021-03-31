using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShahrKoodak.Core.Services.Interfaces;
using ShahrKoodak.DataLayer.Entities.Product;

namespace ShahrKoodak.Web.Pages.Admin.ProductGroups
{
    public class IndexModel : PageModel
    {
        private IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }
        public List<DataLayer.Entities.Product.ProductGroup> ProductGroups { get; set; }
        public void OnGet()
        {
            ProductGroups = _productService.GetAllGroup();
        }
    }
}