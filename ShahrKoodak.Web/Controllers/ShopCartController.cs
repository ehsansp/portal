using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShahrKoodak.Core.DTOs.Product;
using Microsoft.AspNetCore.Http;
using ShahrKoodak.Core.Security;
using ShahrKoodak.Core.Services.Interfaces;
using ShahrKoodak.DataLayer.Context;

namespace ShahrKoodak.Web.Controllers
{
    public class ShopCartController : Controller
    {
        private IProductService _productService;

        public ShopCartController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            List<ShopCartViewModel> list = new List<ShopCartViewModel>();
            if (HttpContext.Session.GetString("ShopCart") != null)
            {
                List<ShopCartItem> cart = HttpContext.Session.GetComplexData<List<ShopCartItem>>("ShopCart");
                foreach (var shopCartItem in cart)
                {
                    var product = _productService.GetProductById(shopCartItem.ProductId);
                    list.Add(new ShopCartViewModel()
                    {
                        ProductId = shopCartItem.ProductId,
                        Count = shopCartItem.Count,
                        Title = product.ProductTitle,
                        Price = product.StarNumber,
                        ImageName = product.ProductImageName
                    });
                }
            }
            return View(list);
        }
        public int AddToCart(int id)
        {
            List<ShopCartItem> cart = new List<ShopCartItem>();


            if (HttpContext.Session.GetString("ShopCart") != null)
            {
                cart = HttpContext.Session.GetComplexData<List<ShopCartItem>>("ShopCart");
            }

            if (cart.Any(p => p.ProductId == id))
            {
                int index = cart.FindIndex(p => p.ProductId == id);
                cart[index].Count += 1;
            }
            else
            {
                cart.Add(new ShopCartItem()
                {
                    ProductId = id,
                    Count = 1
                });
            }




            HttpContext.Session.SetComplexData("ShopCart", cart);

            return cart.Sum(p => p.Count);
        }

        public int ShopCartCount()
        {
            int count = 0;
            List<ShopCartItem> cart = new List<ShopCartItem>();
            if (HttpContext.Session.GetString("ShopCart") != null)
            {
                cart = HttpContext.Session.GetComplexData<List<ShopCartItem>>("ShopCart");
                count = cart.Sum(p => p.Count);
            }

            return count;
        }

        public ActionResult RemoveFromCart(int id)
        {
            List<ShopCartItem> cart = HttpContext.Session.GetComplexData<List<ShopCartItem>>("ShopCart");
            int index = cart.FindIndex(p => p.ProductId == id);
            cart.RemoveAt(index);
            HttpContext.Session.SetComplexData("ShopCart", cart);
            return Redirect("Index");
        }
    }
}