using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace EtkinlikTakip.Controllers
{
    public class LoginController : Controller
    {
        UserRoleManager userRolemngr = new UserRoleManager(new EfUserRoleRepository());

        [AllowAnonymous]
        public IActionResult Login()
        {
            //if (Request.Cookies["UserId"] != null)
            //{
            //    var userRole = userRolemngr.GetUserRoleById(long.Parse(Request.Cookies["UserId"]));
            //    if (userRole != null)
            //    {
            //        var claims = new List<Claim>//authorize için yetki veriliyor
            //        {
            //            new Claim(ClaimTypes.Name,userRole[0].User.UserName),
            //            new Claim(ClaimTypes.Role,userRole[0].Role.RoleName)//değiştirilecek
            //        };
            //        var userIdentity = new ClaimsIdentity(claims, "User Identity");
            //        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            //        await HttpContext.SignInAsync(principal);

            //        CookieOptions options = new CookieOptions();
            //        options.Expires = DateTime.Now.AddDays(2);
            //        Response.Cookies.Append("UserId", userRole[0].User.Id.ToString(), options);
            //        return RedirectToAction("Index", "Etkinlik");
            //    }
            //    else
            //    {
            //        return View();
            //    }

            //}
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LoginAsync(UserRole kullanici)
        {
            var userRole = userRolemngr.GetByUserNameAndPass(kullanici.User.UserName, kullanici.User.Password);
            if (userRole.Count != 0)
            {
                var claims = new List<Claim>//authorize için yetki veriliyor
                {
                    new Claim(ClaimTypes.Sid,userRole[0].User.Id.ToString()),
                    new Claim(ClaimTypes.Name,userRole[0].User.UserName),
                    new Claim(ClaimTypes.Role, userRole[0].Role.RoleName),//düzenlenecek
                    new Claim("UserRoles", userRole[0].Role.RoleName)
                };
                var userIdentity = new ClaimsIdentity(claims, "UserIdentity");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                HttpContext.Session.SetString("userId", userRole[0].User.Id.ToString());
                HttpContext.Session.SetString("userName", userRole[0].User.UserName);
                HttpContext.Session.SetString("userRole", userRole[0].Role.RoleName);

                //CookieOptions options = new CookieOptions();
                //options.Expires = DateTime.Now.AddDays(2);//cookie 2 gün tutuluyor
                //Response.Cookies.Append("UserId", userRole[0].User.Id.ToString(), options);

                return RedirectToAction("Index", "Etkinlik");
            }
            return RedirectToAction("Login", "Login");
        }

        public async Task<ActionResult> LogOutAsync()
        {
            Response.Cookies.Delete("UserId");
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Login");
        }

    }
}
