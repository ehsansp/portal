using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShahrKoodak.Core.Services.Interfaces;
using ShahrKoodak.DataLayer.Entities.Product;

namespace ShahrKoodak.Web.Controllers
{
    
    public class StoreController : Controller
    {
        private IUserService _userService;
        private IProductService _productService;

        public StoreController(IUserService userService, IProductService productService)
        {
            _userService = userService;
            _productService = productService;
        }
        [Route("ShowStore/{id}")]
        public IActionResult ShowStore(int id)
        {
            var course = _userService.getStoreByStoreId(id);
            if (course == null)
            {
                return NotFound();
            }

           
            var UserId =course.UserId;
            var username = _userService.getUserById(UserId);
            var userInformation = _userService.GetUserInformation(username.Email);

            var CityName = _userService.getCityById(username.CityId).Name;

            ViewData["Address"] = userInformation.Address;
            ViewData["WebSite"] = userInformation.WebSite;
            ViewData["Tel"] = userInformation.Tel;
            ViewData["CityName"] = CityName;
            var art = _productService.GetArticle(UserId).Item1;
            ViewBag.arti = art;

            return this.View(course);
        }
    }
}