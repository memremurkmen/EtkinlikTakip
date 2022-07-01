﻿using BusinessLayer.Concrete;
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
    public class ActivityManageController : Controller
    {
        ActivityManager activitymngr;
        ActivityInviteManager activityInvitemngr;
        public ActivityManageController()
        {
            activitymngr = new ActivityManager(new EfActivityRepository());
            activityInvitemngr = new ActivityInviteManager(new EfActivityInviteRepository());
        }

        [Authorize(Roles = "Admin,Yetkili")]
        public IActionResult AllActivities()
        {
            var authUser = GetAuthUser();//düzenlenecek
            HttpContext.Session.SetString("userName", authUser.Username);
            HttpContext.Session.SetString("userRole", authUser.Role);
            return View(activitymngr.GetListOrderByCreatedTime(authUser.Grup));
        }

        [Authorize(Roles = "Admin,Yetkili")]
        public ActionResult GetActivityInvitees([DataSourceRequest] DataSourceRequest request, long activityId)
        {
            return Json(activityInvitemngr.GetInvitees(activityId).ToDataSourceResult(request));
        }

        [AcceptVerbs("Post")]
        [Authorize(Roles = "Admin")]
        public ActionResult EditingPopup_UpdateEtkinlik([DataSourceRequest] DataSourceRequest request, ActivityViewModel guncelEtkinlik)
        {
            if (guncelEtkinlik != null)
            {

            }

            return Json(new[] { guncelEtkinlik }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Yetkili")]
        public ActionResult ConfirmActivity(long activityId)
        {
            try
            {
                var authUser = GetAuthUser();
                activitymngr.ChangeActivityConfirmation(activityId, true, authUser.userId, DateTime.Now);
                return Json(ModelState.ToDataSourceResult());
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Yetkili")]
        public ActionResult DeleteActivity(long activityId)
        {
            try
            {
                var authUser = GetAuthUser();
                activitymngr.ActivityDeleteById(activityId, authUser.userId, DateTime.Now);
                return Json(ModelState.ToDataSourceResult());
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Yetkili")]
        public ActionResult ConfirmInvitedUser(Guid invitedUserId)
        {
            try
            {
                var authUser = GetAuthUser();
                activityInvitemngr.ChangeInviteConfirmation(invitedUserId, true, authUser.userId, DateTime.Now);
                return Json(ModelState.ToDataSourceResult());
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Yetkili")]
        public ActionResult DeleteInvitedUser(Guid invitedUserId)
        {
            try
            {
                var authUser = GetAuthUser();
                activityInvitemngr.DeleteActivityInviteById(invitedUserId, authUser.userId, DateTime.Now);
                return Json(ModelState.ToDataSourceResult());
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeletedActivities()
        {
            var authUser = GetAuthUser();
            HttpContext.Session.SetString("userName", authUser.Username);
            HttpContext.Session.SetString("userRole", authUser.Role);
            return View(activitymngr.GetListOrderByDeletedTime());
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
    }
}
