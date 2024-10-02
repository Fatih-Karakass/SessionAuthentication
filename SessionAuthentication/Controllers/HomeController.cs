using Microsoft.AspNetCore.Mvc;
using SessionAuthentication.Custom_attribute;
using SessionAuthentication.Models;
using System.Diagnostics;

namespace SessionAuthentication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Auth]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if(model.Name=="fatih" & model.Password=="1")
            {
                HttpContext.Session.SetString("UserName", model.Name);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Geçersiz kullanýcý adý veya þifre");
            return View();

        }
        [Auth]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
