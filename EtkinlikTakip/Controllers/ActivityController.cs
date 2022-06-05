using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EtkinlikTakip.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace EtkinlikTakip.Controllers
{
    public class ActivityController : Controller
    {
        ActivityManager activitymngr = new ActivityManager(new EfActivityRepository());

        [HttpGet]
        [Authorize(Roles = "Admin,Yetkili,Personel")]
        public IActionResult Index()
        {
            var authUser = GetAuthUser();
            HttpContext.Session.SetString("userName", authUser.Username);
            HttpContext.Session.SetString("userRole", authUser.Role);
            return View();
        }


        [Authorize(Roles = "Admin,Yetkili,Personel")]
        public virtual JsonResult ActivityRead([DataSourceRequest] DataSourceRequest request)
        {
            var activities = activitymngr.GetList();
            foreach (Activity activity in activities)
            {
                activity.Start = activity.Start.AddHours(3);
                activity.End = activity.End.AddHours(3);
            }
            return Json(activities.ToDataSourceResult(request));
        }
        [Authorize(Roles = "Admin,Yetkili")]
        public virtual JsonResult ActivityCreate([DataSourceRequest] DataSourceRequest request, Activity activity)
        {
            var authUser = GetAuthUser();
            activity.CreateTime = DateTime.Now;
            activity.CreateBy = authUser.userId;
            activitymngr.ActivityAdd(activity);
            return Json(new[] { activity }.ToDataSourceResult(request, ModelState));
        }
        [Authorize(Roles = "Admin,Yetkili")]
        public virtual JsonResult ActivityUpdate([DataSourceRequest] DataSourceRequest request, Activity activity)
        {
            if (ModelState.IsValid)
            {
                var authUser = GetAuthUser();
                activity.UpdateTime = DateTime.Now;
                activity.UpdateBy = authUser.userId;
                activitymngr.ActivityUpdate(activity);
            }

            return Json(new[] { activity }.ToDataSourceResult(request, ModelState));
        }
        [Authorize(Roles = "Admin,Yetkili")]
        public virtual JsonResult ActivityDestroy([DataSourceRequest] DataSourceRequest request, Activity activity)
        {
            if (ModelState.IsValid)
            {
                var authUser = GetAuthUser();
                activity.DeleteTime = DateTime.Now;
                activity.DeleteBy = authUser.userId;
                activitymngr.ActivityDelete(activity);
            }

            return Json(new[] { activity }.ToDataSourceResult(request, ModelState));
        }
        private UserModel GetAuthUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new UserModel
                {
                    userId = long.Parse(userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Sid)?.Value),
                    Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Name)?.Value,
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }

        [HttpPost]
        public IActionResult InviteRequest(long activityId, Guid invitedUserId)
        {
            if (true)//etkinliğe başvuru yapmak istenen kişini zaten başvuru yapıp yapmadığı kontrol edilecek
            {
                return Json(new { success = true, response = true });
            }
            else
            {
                return Json(new { success = false, response = false });
            }
        }

        public IActionResult GetAllUser()
        {
            UserManager usermngr = new UserManager(new EfUserRepository());
            var userList = usermngr.GetList();
            return Json(new { success = true, users = userList });
        }
    }
}
