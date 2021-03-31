using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShahrKoodak.Core.Convertors;
using ShahrKoodak.Core.DTOs.User;
using ShahrKoodak.Core.Services.Interfaces;
using ShahrKoodak.DataLayer.Context;
using ShahrKoodak.DataLayer.Entities.Product;

namespace ShahrKoodak.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private IUserService _userService;
        private ShahrContext _context;

        public ProductController(IProductService productService, IUserService userService, ShahrContext context)
        {
            _productService = productService;
            _userService = userService;
            _context = context;
        }
        
        public IActionResult Index(int pageId = 1, string filter = "", string getType = "all", string orderByType = "date", int startPrice = 0, int endPrice = 0, List<int> selectedGroups = null, List<int> selectedBrands = null)
        {
            



            ViewBag.selectedGroups = selectedGroups;
            ViewBag.selectedBrands = selectedBrands;

            ViewBag.Groups = _productService.GetAllGroup();
            ViewBag.pageId = pageId;
            return View(_productService.GetProduct(pageId, filter, getType, orderByType, startPrice, endPrice, selectedGroups, 24));
        }

        [HttpGet("ShowProduct/{id}/{title}", Name = "GetProduct")]
        [Route("ShowProduct/{id}")]
        public IActionResult ShowProduct(int id, string title)
        {
            
           
            var UserId = _productService.GetProductById(id).UserId;
            var username = _userService.getUserById(UserId);
            var userInformation = _userService.GetUserInformation(username.Email);
            var storeInformation = _userService.getStoreByUserId(UserId);
            var CityName = _userService.getCityById(username.CityId).Name;

            ViewData["Logo"] = storeInformation.Logo;
            ViewData["StoreName"] = storeInformation.Name;
            ViewData["StoreId"] = storeInformation.StoreId;
            ViewData["Banner"] = storeInformation.Banner;
            ViewData["Address"] = userInformation.Address;
            ViewData["Tel"] = userInformation.UserName;
            ViewData["CityName"] = CityName;

            var course = _productService.GetProductForShow(id);
            if (course == null)
            {
                return NotFound();
            }

            int c = course.Counter;
            c++;
            course.Counter = c;
            _context.Update(course);
            _context.SaveChanges();
            ViewBag.F = _productService.ShowFeature(id);
            string friendlyTitle = FriendlyUrlHelper.GetFriendlyTitle(course.ProductTitle);

            if (!string.Equals(friendlyTitle, title, StringComparison.Ordinal))
            {
                return this.RedirectToRoutePermanent("GetProduct", new { id = id, title = friendlyTitle });
            }
            
            return this.View(course);
        }
        
    }
}