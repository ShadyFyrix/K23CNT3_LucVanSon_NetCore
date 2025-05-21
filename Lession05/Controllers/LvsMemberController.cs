using Lession05.Models.DataModels;
using Microsoft.AspNetCore.Mvc;
namespace Lession05.Controllers
{
    public class LvsMemberController : Controller
    {
        private static List<LvsMember> LvsListMembers = new List<LvsMember>()
        {
                new LvsMember
                {
                    LvsMemberId = "2310900087",
                    LvsUserName = "ShadyFyrix",
                    LvsPassword = "pass2005",
                    LvsFullName = "Lục Văn Sơn",
                    LvsEmail = "shadyfyrix@gmail.com"
                },
                new LvsMember
                {
                    LvsMemberId = "2",
                    LvsUserName = "user02",
                    LvsPassword = "pass02",
                    LvsFullName = "Tran Thi B",
                    LvsEmail = "b@example.com"
                },
                new LvsMember
                {
                    LvsMemberId = "3",
                    LvsUserName = "user03",
                    LvsPassword = "pass03",
                    LvsFullName = "Le Van C",
                    LvsEmail = "c@example.com"
                },
                new LvsMember
                {
                    LvsMemberId = "4",
                    LvsUserName = "user04",
                    LvsPassword = "pass04",
                    LvsFullName = "Pham Thi D",
                    LvsEmail = "d@example.com"
                },
                new LvsMember
                {
                    LvsMemberId = "5",
                    LvsUserName = "user05",
                    LvsPassword = "pass05",
                    LvsFullName = "Hoang Van E",
                    LvsEmail = "e@example.com"
                }
        };
        public IActionResult LvsIndex() 
        {
            return View(LvsListMembers); 
        }
    }
}
