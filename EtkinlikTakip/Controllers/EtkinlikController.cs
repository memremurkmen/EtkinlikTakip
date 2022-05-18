using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace EtkinlikTakip.Controllers
{
    public class EtkinlikController : Controller
    {
        EtkinlikManager etkinlikmngr = new EtkinlikManager(new EfEtkinlikRepository());
        public IActionResult Index()
        {
            return View();
        }


        public virtual JsonResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(etkinlikmngr.GetList().ToDataSourceResult(request));
        }

        public virtual JsonResult Create([DataSourceRequest] DataSourceRequest request, Etkinlik etkinlik)
        {
            etkinlikmngr.EtkinlikAdd(etkinlik);
            return Json(new[] { etkinlik }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Update([DataSourceRequest] DataSourceRequest request, Etkinlik etkinlik)
        {
            if (ModelState.IsValid)
            {
                etkinlikmngr.EtkinlikUpdate(etkinlik);
            }

            return Json(new[] { etkinlik }.ToDataSourceResult(request, ModelState));
        }

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
