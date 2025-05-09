using System.Diagnostics;
using LvsLession03.Models;
using Microsoft.AspNetCore.Mvc;

namespace LvsLession03.Controllers
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
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
