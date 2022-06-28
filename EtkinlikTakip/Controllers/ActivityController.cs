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
        public IActionResult Activities()
        {
            ViewBag.locationCntrl = true;
            var authUser = GetAuthUser();
            HttpContext.Session.SetString("userName", authUser.Username);
            HttpContext.Session.SetString("userRole", authUser.Role);
            return View();
        }

        [Authorize(Roles = "Admin,Yetkili,Personel")]
        public virtual JsonResult ActivityRead([DataSourceRequest] DataSourceRequest request)
        {
            ViewBag.locationCntrl = true;
            var activities = activitymngr.GetConfirmedList();
            foreach (Activity activity in activities)
            {
                activity.Start = activity.Start.AddHours(3);
                activity.End = activity.End.AddHours(3);
            }
            return Json(activities.ToDataSourceResult(request));
        }

        [Authorize(Roles = "Admin,Yetkili")]
        public IActionResult ActivityCreate([DataSourceRequest] DataSourceRequest request, Activity activity)
        {
            var authUser = GetAuthUser();
            if (authUser != null)
            {
                if (!activitymngr.CheckActivityLocationConflict(activity))
                {
                    if (authUser.Role == "Admin")
                    {
                        activity.IsConfirmed = true;
                        activity.ConfirmedBy = authUser.userId;
                        activity.ConfirmedTime = DateTime.Now;
                    }
                    activity.CreatedTime = DateTime.Now;
                    activity.CreatedBy = authUser.userId;
                    activitymngr.ActivityAdd(activity);
                    ViewBag.locationCntrl = true;
                    return Json(new[] { activity }.ToDataSourceResult(request, ModelState));
                }
                else
                {
                    ViewBag.locationCntrl = false;
                    return View();
                }

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [Authorize(Roles = "Admin,Yetkili")]
        public virtual JsonResult ActivityUpdate([DataSourceRequest] DataSourceRequest request, Activity activity)
        {
            if (ModelState.IsValid)
            {
                var authUser = GetAuthUser();
                if (authUser.Role == "Admin" || authUser.Grup == activity.Grup)
                {
                    if (!activitymngr.CheckActivityLocationConflict(activity))
                    {
                        activity.UpdatedTime = DateTime.Now;
                        activity.UpdatedBy = authUser.userId;
                        activitymngr.ActivityUpdate(activity);
                        ViewBag.locationCntrl = true;
                        return Json(new[] { activity }.ToDataSourceResult(request, ModelState));
                    }
                    else
                    {
                        ViewBag.locationCntrl = false;
                        return Json(null);
                    }
                }
                else
                {
                    ViewBag.activityAccess = false;
                    return Json(null);
                }
            }
            return Json(null);
        }

        [Authorize(Roles = "Admin,Yetkili")]
        public virtual JsonResult ActivityDestroy([DataSourceRequest] DataSourceRequest request, Activity activity)
        {
            if (ModelState.IsValid)
            {
                var authUser = GetAuthUser();
                if (authUser.Role == "Admin" || authUser.Grup == activity.Grup)
                {
                    activitymngr.ActivityDeleteById(activity.ID, authUser.userId, DateTime.Now);
                }
                else
                {
                    ViewBag.activityAccess = false;
                    return Json(null);
                }
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
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,
                    Grup = userClaims.FirstOrDefault(o => o.Type == "Grup")?.Value
                };
            }
            return null;
        }


        [HttpPost]
        [Authorize(Roles = "Admin,Yetkili,Personel")]
        public IActionResult InviteRequest(long activityId, long invitedUserId)
        {
            var authUser = GetAuthUser();
            if (authUser.Role == "Personel" || authUser.Grup == activitymngr.GetById(activityId).Grup)
            {
                ActivityInviteManager activityInvitemngr = new ActivityInviteManager(new EfActivityInviteRepository());
                ActivityInvite ai = activityInvitemngr.CheckActivityInvite(activityId, invitedUserId);
                bool aiEmptyKontenjan = activitymngr.CheckEmptyKontenjan(activityId);
                if (!aiEmptyKontenjan)
                {
                    return Json(new { success = true, responseText = "Yeterli kontenjan yok.", isInvited = true });
                }
                else if (ai == null)//etkinliğe başvuru yapmak istenen kişini zaten başvuru yapıp yapmadığı kontrol edilecek
                {
                    ActivityInvite invitedUser = new ActivityInvite();
                    invitedUser.InvitedUserId = invitedUserId;
                    invitedUser.ActivityId = activityId;
                    invitedUser.CreatedBy = authUser.userId;
                    invitedUser.CreatedTime = DateTime.Now;
                    if (authUser.Role == "Admin" || authUser.Role == "Yetkili")
                    {
                        invitedUser.IsConfirmed = true;
                        invitedUser.ConfirmedBy = authUser.userId;
                        invitedUser.ConfirmedTime = DateTime.Now;
                    }
                    activityInvitemngr.AddActivityInvite(invitedUser);
                    return Json(new { success = true, responseText = "Davet isteği atıldı.", isInvited = false });
                }
                else if (ai != null)
                {
                    if (ai.IsConfirmed)
                    {
                        return Json(new { success = true, responseText = "Zaten başvuru yapılmış ve başvurun kabul edilmiş.", isInvited = true });
                    }
                    return Json(new { success = true, responseText = "Zaten başvuru yapılmış.", isInvited = true });
                }
                return Json(new { success = false, responseText = "Davet isteği yollanırken bir hata ile karşılaşıldı!" });
            }
            else
            {
                return Json(new { success = false, responseText = "Davet isteği yollamak için yetkiniz yok!" });
            }
        }

        [Authorize(Roles = "Admin,Yetkili")]
        public JsonResult GetAllUsers()
        {
            UserManager usermngr = new UserManager(new EfUserRepository());
            var userList = usermngr.GetList();
            return Json(userList);
        }

        public JsonResult GetAllLocations([DataSourceRequest] DataSourceRequest request)
        {
            IList<string> rooms = new List<string>() {
                { "Büyük Toplantı Salonu" },
                { "Küçük Toplantı Salonu" },
                { "Sunum Salonu" }
            };
            return Json(rooms.ToDataSourceResult(request));
        }

        [Authorize(Roles = "Admin,Yetkili")]
        public JsonResult GetInvitedUsers(long Id)
        {
            ActivityInviteManager aimngr = new ActivityInviteManager(new EfActivityInviteRepository());
            var users = aimngr.GetInvitees(Id);
            return Json(users);
        }




        [Authorize(Roles = "Admin,Yetkili,Personel")]
        public IActionResult InvitedActivities()
        {
            var authUser = GetAuthUser();
            HttpContext.Session.SetString("userName", authUser.Username);
            HttpContext.Session.SetString("userRole", authUser.Role);
            return View(activitymngr.GetListOrderByCreatedTimeAndByUserId(authUser.userId));
        }

        [Authorize(Roles = "Admin,Yetkili")]
        public ActionResult GetConfirmedActivityInvitees([DataSourceRequest] DataSourceRequest request, long activityId)
        {
            ActivityInviteManager activityInvitemngr = new ActivityInviteManager(new EfActivityInviteRepository());
            var users = activityInvitemngr.GetInvitees(activityId, true);
            return Json(users.ToDataSourceResult(request));
        }
    }
}
