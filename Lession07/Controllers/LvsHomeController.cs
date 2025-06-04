using System.Diagnostics;
using Lession07.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lession07.Controllers
{
    public class LvsHomeController : Controller
    {
        private readonly ILogger<LvsHomeController> _logger;

        public LvsHomeController(ILogger<LvsHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult LvsIndex()
        {
            return View();
        }

        public IActionResult LvsAbout()
        {
            ViewBag.StudentId = "2310900087";
            ViewBag.StudentName = "Lục Văn Sơn";
            ViewBag.Email = "shadyfyrix@gmail.com";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
