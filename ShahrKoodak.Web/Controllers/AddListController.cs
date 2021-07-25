using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShahrKoodak.Core.DTOs.Product;
using ShahrKoodak.Core.Security;
using ShahrKoodak.Core.Services.Interfaces;

namespace ShahrKoodak.Web.Controllers
{
    public class AddListController : Controller
    {
        private IProductService _productService;

        public AddListController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            List<ShopCartViewModel> list = new List<ShopCartViewModel>();
            if (HttpContext.Session.GetString("AddList") != null)
            {
                List<ShopCartItem> cart = HttpContext.Session.GetComplexData<List<ShopCartItem>>("AddList");
                foreach (var shopCartItem in cart)
                {
                    var product = _productService.GetProductById(shopCartItem.ProductId);
                    list.Add(new ShopCartViewModel()
                    {
                        ProductId = shopCartItem.ProductId,
                        Count = shopCartItem.Count,
                        Title = product.ProductTitle,
                        Price = product.Price,
                        Sum = shopCartItem.Count * product.Price,
                        ImageName = product.ProductImageName
                    });
                }
            }

            return View(list);
        }


        public int AddToList(int id)
        {
            List<ShopCartItem> cart = new List<ShopCartItem>();


            if (HttpContext.Session.GetString("AddList") != null)
            {
                cart = HttpContext.Session.GetComplexData<List<ShopCartItem>>("AddList");
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




            HttpContext.Session.SetComplexData("AddList", cart);

            return cart.Sum(p => p.Count);
        }

        public int ListCount()
        {
            int count = 0;
            List<ShopCartItem> cart = new List<ShopCartItem>();
            if (HttpContext.Session.GetString("AddList") != null)
            {
                cart = HttpContext.Session.GetComplexData<List<ShopCartItem>>("AddList");
                count = cart.Sum(p => p.Count);
            }

            return count;
        }

        public ActionResult RemoveList(int id)
        {
            List<ShopCartItem> cart = HttpContext.Session.GetComplexData<List<ShopCartItem>>("AddList");
            int index = cart.FindIndex(p => p.ProductId == id);
            cart.RemoveAt(index);
            HttpContext.Session.SetComplexData("AddList", cart);
            return Redirect("/AddList");
        }
    }
}
