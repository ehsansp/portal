using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShahrKoodak.Core.Services.Interfaces;
using ShahrKoodak.DataLayer.Context;
using ShahrKoodak.DataLayer.Entities.Product;

namespace ShahrKoodak.Web.Pages.Admin.Product
{
    public class ActiveModel : PageModel
    {
        private IProductService _productService;
        private ShahrContext _context;

        public ActiveModel(IProductService productService, ShahrContext context)
        {
            _productService = productService;
            _context = context;
        }
        [BindProperty] public product Product { get; set; }
        public void OnGet(int id)
        {
            Product = _productService.GetProductById(id);
        }

        public IActionResult OnPost(int id, bool e)
        {
            var product = _context.Product.Find(id);
            product.IsActive = true;
            _context.SaveChanges();

            return RedirectToPage("Index");
        }


    }
}