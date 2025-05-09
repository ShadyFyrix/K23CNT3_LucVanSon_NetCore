using Microsoft.AspNetCore.Mvc;
using LvsLession03.Models;

namespace LvsLession03.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index(int id)
        {
            List<Account> accounts = new List<Account>
            {
                new Account ()
                {
                    Id = 1,
                    Name = "Lục Văn Sơn",
                    Email="shadyfyrix@gmail.com",
                    Address="Thanh Hóa",
                    Avatar=Url.Content("~/Avatar/2.jpg"),
                    Gender=1,
                    Bio="HEY there, my name is shady",
                    Birthday= new DateTime(2005,2,13)
                },
                new Account()
                {
                    Id = 2,
                    Name = "Lục Văn Eyja",
                    Email="shadyfyrix@gmail.com",
                    Address="Hà Nội",
                    Avatar=Url.Content("~/Avatar/6.jpg"),
                    Gender=1,
                    Bio="HEY there, my name is Eyja",
                    Birthday= new DateTime(2005,2,13)
                },
                new Account()
                {
                    Id = 4,
                    Name = "Lục Văn 69",
                    Email="shadyfyrix@gmail.com",
                    Address="Thanh",
                    Avatar=Url.Content("~/Avatar/1.jpg"),
                    Gender=1,
                    Bio="HEY there, my name is shad1313",
                    Birthday= new DateTime(2005,2,13)
                },
            }; 
            ViewBag.Accounts = accounts;
            return View();
        }
        [Route("ho-so-cua-toi", Name = "Profile")]
        public IActionResult Profile(int id)
            {
            List<Account> accounts = new List<Account>
            {
                new Account ()
                {
                    Id = 1,
                    Name = "Lục Văn Sơn",
                    Email="shadyfyrix@gmail.com",
                    Address="Thanh Hóa",
                    Avatar=Url.Content("~/Avatar/2.jpg"),
                    Gender=1,
                    Bio="HEY there, my name is shady",
                    Birthday= new DateTime(2005,2,13)
                },
                new Account()
                {
                    Id = 2,
                    Name = "Lục Văn Eyja",
                    Email="shadyfyrix@gmail.com",
                    Address="Hà Nội",
                    Avatar=Url.Content("~/Avatar/6.jpg"),
                    Gender=1,
                    Bio="HEY there, my name is Eyja",
                    Birthday= new DateTime(2005,2,13)
                },
                new Account()
                {
                    Id = 4,
                    Name = "Lục Văn 69",
                    Email="shadyfyrix@gmail.com",
                    Address="Thanh",
                    Avatar=Url.Content("~/Avatar/1.jpg"),
                    Gender=1,
                    Bio="HEY there, my name is shady113132",
                    Birthday= new DateTime(2005,2,13)
                },
            };
            Account account = accounts.FirstOrDefault(acc => acc.Id == id);
            ViewBag.account = account;
            return View();
        }
    }
}
