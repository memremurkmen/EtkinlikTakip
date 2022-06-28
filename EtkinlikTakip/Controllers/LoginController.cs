using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EtkinlikTakip.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EtkinlikTakip.Controllers
{
    public class LoginController : Controller
    {
        UserRoleManager userRolemngr = new UserRoleManager(new EfUserRoleRepository());


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> LoginAsync()
        {
            if (Request.Cookies["UserId"] != null)
            {
                var userRole = userRolemngr.GetUserRoleById(long.Parse(Request.Cookies["UserId"]));
                if (userRole != null)
                {
                    var claims = new List<Claim>//authorize için yetki veriliyor
                    {
                        new Claim(ClaimTypes.Sid,userRole[0].User.Id.ToString()),//değiştirilecek
                        new Claim(ClaimTypes.Name,userRole[0].User.UserName),//değiştirilecek
                        new Claim(ClaimTypes.Role,userRole[0].Role.RoleName),//değiştirilecek
                        new Claim("Grup",userRole[0].User.Grup)//değiştirilecek
                    };
                    var userIdentity = new ClaimsIdentity(claims, "User Identity");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);

                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddDays(2);
                    Response.Cookies.Append("UserId", userRole[0].User.Id.ToString(), options);
                    return RedirectToAction("Activities", "Activity");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LoginAsync(string username, string password)
        {
            var userRole = userRolemngr.GetByUserNameAndPass(username, password);
            if (userRole.Count != 0)
            {
                var claims = new List<Claim>//authorize için yetki veriliyor
                {
                    new Claim(ClaimTypes.Sid,userRole[0].User.Id.ToString()),//düzenlenecek
                    new Claim(ClaimTypes.Name,userRole[0].User.UserName),//düzenlenecek
                    new Claim(ClaimTypes.Role, userRole[0].Role.RoleName),//düzenlenecek
                    new Claim("Grup",userRole[0].User.Grup)//değiştirilecek
                };
                var userIdentity = new ClaimsIdentity(claims, "UserIdentity");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                HttpContext.Session.SetString("userId", userRole[0].User.Id.ToString());
                HttpContext.Session.SetString("userName", userRole[0].User.UserName);
                HttpContext.Session.SetString("userRole", userRole[0].Role.RoleName);
                return Json(new { success = true, loggedIn = true });
            }
            return Json(new { success = true, loggedIn = false });
        }

        public async Task<ActionResult> LogOutAsync()
        {
            //Response.Cookies.Delete("UserId");
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Login");
        }


    }
}
