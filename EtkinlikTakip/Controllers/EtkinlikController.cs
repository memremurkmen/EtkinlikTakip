using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;

namespace EtkinlikTakip.Controllers
{
    public class EtkinlikController : Controller
    {
        EtkinlikManager etkinlikmngr = new EtkinlikManager(new EfEtkinlikRepository());


        [Authorize(Roles = "Admin,Yetkili,Personel")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Yetkili,Personel")]
        public virtual JsonResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var etkinlikler = etkinlikmngr.GetList();
            for (int i = 0; i < etkinlikler.Count; i++)
            {
                etkinlikler[i].Start = etkinlikler[i].Start.AddHours(3);
                etkinlikler[i].End = etkinlikler[i].End.AddHours(3);
            }
            return Json(etkinlikler.ToDataSourceResult(request));
        }
        [Authorize(Roles = "Admin,Yetkili")]
        public virtual JsonResult Create([DataSourceRequest] DataSourceRequest request, Etkinlik etkinlik)
        {
            etkinlik.CreateTime = DateTime.Now;
            etkinlikmngr.EtkinlikAdd(etkinlik);
            return Json(new[] { etkinlik }.ToDataSourceResult(request, ModelState));
        }
        [Authorize(Roles = "Admin,Yetkili")]
        public virtual JsonResult Update([DataSourceRequest] DataSourceRequest request, Etkinlik etkinlik)
        {
            if (ModelState.IsValid)
            {
                etkinlik.UpdateTime = DateTime.Now;
                etkinlikmngr.EtkinlikUpdate(etkinlik);
            }

            return Json(new[] { etkinlik }.ToDataSourceResult(request, ModelState));
        }
        [Authorize(Roles = "Admin,Yetkili")]
        public virtual JsonResult Destroy([DataSourceRequest] DataSourceRequest request, Etkinlik etkinlik)
        {
            if (ModelState.IsValid)
            {
                etkinlikmngr.EtkinlikDelete(etkinlik);
            }

            return Json(new[] { etkinlik }.ToDataSourceResult(request, ModelState));
        }




    }
}
