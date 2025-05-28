using Microsoft.AspNetCore.Mvc;
using LvsLab06.Models;
using System.Collections.Generic;
using System.Linq;

namespace LvsLab06.Controllers
{
    public class LvsEmployeeController : Controller
    {
        private static List<LvsEmployee> lvsListEmployee = new List<LvsEmployee>
        {
            new LvsEmployee { LvsId = "NV001", LvsName = "Lục Văn Sơn", LvsBirthDay = new DateTime(2005, 2, 13),
                            LvsEmail = "shadyfyrix@company.com", LvsPhone = "0123456789", LvsSalary = 10000000, LvsStatus = true },
            new LvsEmployee { LvsId = "NV002", LvsName = "Nguyễn Thị Eyja", LvsBirthDay = new DateTime(2000, 5, 15),
                            LvsEmail = "hant@company.com", LvsPhone = "0987654321", LvsSalary = 12000000, LvsStatus = true },
            new LvsEmployee { LvsId = "NV003", LvsName = "Trần Văn Đức", LvsBirthDay = new DateTime(1990, 8, 20),
                            LvsEmail = "ductv@company.com", LvsPhone = "0369852147", LvsSalary = 15000000, LvsStatus = true },
            new LvsEmployee { LvsId = "NV004", LvsName = "Phạm Thị Mai", LvsBirthDay = new DateTime(1988, 3, 10),
                            LvsEmail = "maipm@company.com", LvsPhone = "0587412369", LvsSalary = 11000000, LvsStatus = false },
            new LvsEmployee { LvsId = "NV005", LvsName = "Hoàng Văn Tùng", LvsBirthDay = new DateTime(1992, 11, 25),
                            LvsEmail = "tunghv@company.com", LvsPhone = "0741258963", LvsSalary = 13000000, LvsStatus = true }
        };

        public IActionResult LvsIndex()
        {
            return View(lvsListEmployee);
        }

        public IActionResult LvsCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LvsCreateSubmit(LvsEmployee employee)
        {
            if (ModelState.IsValid)
            {
                lvsListEmployee.Add(employee);
                return RedirectToAction("LvsIndex");
            }
            return View("LvsCreate", employee);
        }

        public IActionResult LvsEdit(string id)
        {
            var employee = lvsListEmployee.FirstOrDefault(e => e.LvsId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult LvsEditPUT(LvsEmployee updatedEmployee)
        {
            if (ModelState.IsValid)
            {
                var existingEmployee = lvsListEmployee.FirstOrDefault(e => e.LvsId == updatedEmployee.LvsId);
                if (existingEmployee != null)
                {
                    existingEmployee.LvsName = updatedEmployee.LvsName;
                    existingEmployee.LvsBirthDay = updatedEmployee.LvsBirthDay;
                    existingEmployee.LvsEmail = updatedEmployee.LvsEmail;
                    existingEmployee.LvsPhone = updatedEmployee.LvsPhone;
                    existingEmployee.LvsSalary = updatedEmployee.LvsSalary;
                    existingEmployee.LvsStatus = updatedEmployee.LvsStatus;
                }
                return RedirectToAction("LvsIndex");
            }
            return View("LvsEdit", updatedEmployee);
        }

        public IActionResult LvsDelete(string id)
        {
            var employee = lvsListEmployee.FirstOrDefault(e => e.LvsId == id);
            if (employee != null)
            {
                lvsListEmployee.Remove(employee);
            }
            return RedirectToAction("LvsIndex");
        }
    }
}