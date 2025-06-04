using Microsoft.AspNetCore.Mvc;
using Lession07.Models;
using System.Collections.Generic;
using System.Linq;

namespace Lession07.Controllers
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
            var LvsEmployee = new LvsEmployee();
            return View(LvsEmployee);
        }

        [HttpPost]
        public IActionResult LvsCreate(LvsEmployee employee)
        {
            try
            {
                employee.LvsId = lvsListEmployee.Max(x => x.LvsId) + 1;
                lvsListEmployee.Add(employee);
                return RedirectToAction(nameof(LvsIndex));
            }
            catch {

                return View("LvsCreate", employee);
            }
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
        public IActionResult LvsEdit(string LvsId , LvsEmployee updatedEmployee)
        {
            try
            {
                for (int i = 0; i < lvsListEmployee.Count();i++)
                {
                    if (lvsListEmployee[i].LvsId == LvsId)
                    {
                        lvsListEmployee[i] = updatedEmployee;
                        break;
                    }    
                }
                return RedirectToAction(nameof(LvsIndex));
            }
            catch
            {
                return View("LvsEdit", updatedEmployee);
            }
           
        }
        public ActionResult LvsDetails (string id)
        {
            var employee = lvsListEmployee.FirstOrDefault(e => e.LvsId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
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