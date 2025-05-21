using System.Diagnostics;
using Lession05.Models;
using Microsoft.AspNetCore.Mvc;
using Lession05.Models.DataModels;

namespace Lession05.Controllers
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
            LvsMember LvsMember = new LvsMember();
            LvsMember.LvsMemberId = Guid.NewGuid().ToString();
            LvsMember.LvsUserName = "ShadyFyrix";
            LvsMember.LvsPassword = "00101010@";
            LvsMember.LvsFullName = "Lục Văn Sơn";
            LvsMember.LvsEmail = "Shadyfyrix@gmail.com";
            return View(LvsMember);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
