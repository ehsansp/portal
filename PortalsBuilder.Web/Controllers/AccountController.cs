using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalBuilder.Core.Convertors;
using PortalBuilder.Core.DTOs.Staff;
using PortalBuilder.Core.Services.Interfaces;
using PortalBuilder.DataLayer.Context;
using PortalBuilder.Models;

namespace PortalsBuilder.Web.Controllers
{
    public class AccountController : Controller
    {
        private IStaffService _userService;
        private ShahrContext _context;
        private IViewRenderService _viewRender;

        public AccountController(IStaffService userService, ShahrContext context, IViewRenderService viewRender)
        {
            _userService = userService;
            _context = context;
            _viewRender = viewRender;
        }

        #region Login

        [Route("Login")]
        public ActionResult Login(bool EditProfile = false)
        {
            ViewBag.EditProfile = EditProfile;
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginViewModel login)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(login);
            //}

            var user = _userService.LoginUser(login);
            if (user != null)
            {
                if (user.IsActive)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                        new Claim(ClaimTypes.Name,user.Username)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = login.RememberMe
                    };
                    HttpContext.SignInAsync(principal, properties);

                    ViewBag.IsSuccess = true;

                    return View();
                }
                else
                {
                    ModelState.AddModelError("Email", "حساب کاربری شما فعال نمی باشد.");
                }
            }
            ModelState.AddModelError("Email", "کاربری با مشخصات وارد شده یافت نشد.");
            return View(login);
        }

        #endregion


        #region Register


        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
        


        

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            if (_userService.IsExistUserName(register.UserName))
            {
                ModelState.AddModelError("UserName", "شماره همراه قبلا در سیستم ثبت شده است.");
                return View(register);
            }

            Random rnd = new Random();
            string r = "";
            string rr = "";

            r = rnd.Next(1000, 9999).ToString();
            Customer user = new Customer()
            {
                ActiveCode = r,
                Email = register.UserName,
                EncryptedPassword = r,
                CreatedAt = DateTime.Now,
                Username = register.UserName,
                Phone = register.UserName,
                FirstName = ""

            };
            _userService.AddUser(user);

            #region Send Activation Email

            rr = "به هامون خوش آمدید. کد فعالسازی شما: " + r;

            var api2 = await new ServiceReference1.SendSMSSoapClient(new ServiceReference1.SendSMSSoapClient.EndpointConfiguration() { }).SendAsync("FCA2AA2E-F69E-4130-BB73-167F96719CFA", register.UserName, rr, "");
            ViewBag.SendResult = api2.Body.SendResult;
            ViewBag.retStr = api2.Body.retStr;

            #endregion

            return View("Active");
        }

        #endregion

        #region Active

        [Route("Active")]
        public IActionResult Active()
        {
            return View();
        }

        [Route("Active")]
        [HttpPost]
        public IActionResult Active(ActiveViewModel req)
        {
            Customer user = new Customer();
            user = _userService.GetUserByActiveCode(req.code);

            if (user == null)
            {
                ModelState.AddModelError("UserName", "کد وارد شده صحیح نمی باشد.");
                return View("Active");
            }

            ViewBag.IsActive = _userService.ActiveAcount(req.code);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Username)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = true
            };
            HttpContext.SignInAsync(principal, properties);

            ViewBag.IsSuccess = true;
            return View();
        }

        #endregion


        #region SetPassword

        [Route("SetPassword")]
        public IActionResult SetPassword()
        {
            return View();
        }

        [Route("SetPassword")]
        [HttpPost]
        public IActionResult SetPassword(PasswordViewModel req)
        {
            if (!ModelState.IsValid)
                return View(req);


            Customer user = new Customer();
            user = _userService.GetUserByUserName(User.Identity.Name);

            _userService.ChangeUserPassword(user.Username, req.Password);
            ViewBag.IsActive = true;
            return View();
        }

        #endregion

        #region ForgotPassword

        [Route("ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [Route("ForgotPassword")]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel req)
        {
            if (!ModelState.IsValid)
                return View(req);

            Customer user = new Customer();
            user = _userService.GetUserByUserName(req.Email);

            if (user == null)
            {
                ModelState.AddModelError("Email", "این شماره قبلا در سیستم ثبت نشده است.");
                return View(req);
            }



            Random rnd = new Random();
            string r = "";
            string rr = "";

            r = rnd.Next(1000, 9999).ToString();

            user.ActiveCode = r;
            _context.Update(user);
            _context.SaveChanges();



            #region Send Activation Email

            rr = "به هامون خوش آمدید. کد فعالسازی شما: " + r;

            var api2 = await new ServiceReference1.SendSMSSoapClient(new ServiceReference1.SendSMSSoapClient.EndpointConfiguration() { }).SendAsync("FCA2AA2E-F69E-4130-BB73-167F96719CFA", user.Phone, rr, "");
            ViewBag.SendResult = api2.Body.SendResult;
            ViewBag.retStr = api2.Body.retStr;

            #endregion

            return View("Active");
        }

        #endregion


        #region Logout

        [

            Route("Logout")]

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login");
        }

        #endregion
    }
}
