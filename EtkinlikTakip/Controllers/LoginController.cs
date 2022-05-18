using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EtkinlikTakip.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(string ad)
        {
            return RedirectToAction("Index", "Etkinlik");
        }


    }
}
