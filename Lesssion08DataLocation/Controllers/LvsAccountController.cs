using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LvsCoreMVC.LvsModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesssion08DataLocation.Controllers
{
    public class LvsAccountController : Controller
    {
        private static List<LvsAccount> _lvsAccounts = new List<LvsAccount>
{
    new LvsAccount {
        LvsId = 1,
        LvsFullName = "Lục Văn Sơn",
        LvsEmail = "shadyfyrix@gmail.com",
        LvsPhone = "0111111111",
        LvsAddress = "Thanh Hóa",
        LvsAvatar = "https://example.com/avatar1.jpg",
        LvsBirthday = new DateTime(2005, 2, 13),
        LvsGender = "Nam",
        LvsPassword = "password1",
        LvsFacebook = "https://www.facebook.com/ShadyFyrix00/"
    },
    new LvsAccount {
        LvsId = 2,
        LvsFullName = "Trần Thị B",
        LvsEmail = "b.tran@example.com",
        LvsPhone = "0912345678",
        LvsAddress = "TP.HCM",
        LvsAvatar = "https://example.com/avatar2.jpg",
        LvsBirthday = new DateTime(1995, 5, 15),
        LvsGender = "Nữ",
        LvsPassword = "password2",
        LvsFacebook = "https://facebook.com/b.tran"
    },
    new LvsAccount {
        LvsId = 3,
        LvsFullName = "Lê Văn C",
        LvsEmail = "c.le@example.com",
        LvsPhone = "0977123456",
        LvsAddress = "Đà Nẵng",
        LvsAvatar = "",
        LvsBirthday = new DateTime(1985, 10, 20),
        LvsGender = "Nam",
        LvsPassword = "password3",
        LvsFacebook = ""
    }
};

        // GET: LvsAccountController
        public IActionResult LvsIndex()
        {
            return View(_lvsAccounts);
        }

        // GET: LvsAccountController/Details/5
        public IActionResult LvsDetails(int id)
        {
            var account = _lvsAccounts.FirstOrDefault(a => a.LvsId == id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // GET: LvsAccountController/Create
        public IActionResult LvsCreate()
        {
            ViewBag.LvsGender = GetGenderOptions();
            return View(new LvsAccount());
        }

        // POST: LvsAccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LvsCreate(LvsAccount account)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrEmpty(account.LvsFullName))
                {
                    ModelState.AddModelError("LvsFullName", "Họ tên là bắt buộc");
                }

                if (string.IsNullOrEmpty(account.LvsEmail))
                {
                    ModelState.AddModelError("LvsEmail", "Email là bắt buộc");
                }
                else if (!account.LvsEmail.Contains("@"))
                {
                    ModelState.AddModelError("LvsEmail", "Email không hợp lệ");
                }

                if (string.IsNullOrEmpty(account.LvsPhone))
                {
                    ModelState.AddModelError("LvsPhone", "Số điện thoại là bắt buộc");
                }
                else if (account.LvsPhone.Length < 10 || account.LvsPhone.Length > 11)
                {
                    ModelState.AddModelError("LvsPhone", "Số điện thoại phải có 10-11 số");
                }

                if (string.IsNullOrEmpty(account.LvsPassword))
                {
                    ModelState.AddModelError("LvsPassword", "Mật khẩu là bắt buộc");
                }
                else if (account.LvsPassword.Length < 6)
                {
                    ModelState.AddModelError("LvsPassword", "Mật khẩu phải có ít nhất 6 ký tự");
                }

                if (!ModelState.IsValid)
                {
                    ViewBag.LvsGender = GetGenderOptions();
                    return View(account);
                }

                // Generate new ID
                account.LvsId = _lvsAccounts.Max(a => a.LvsId) + 1;
                _lvsAccounts.Add(account);

                return RedirectToAction(nameof(LvsIndex));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Đã xảy ra lỗi khi tạo tài khoản: {ex.Message}");
                ViewBag.LvsGender = GetGenderOptions();
                return View(account);
            }
        }

        // GET: LvsAccountController/Edit/5
        public IActionResult LvsEdit(int id)
        {
            var account = _lvsAccounts.FirstOrDefault(a => a.LvsId == id);
            if (account == null)
            {
                return NotFound();
            }

            ViewBag.LvsGender = GetGenderOptions(account.LvsGender);
            return View(account);
        }

        // POST: LvsAccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LvsEdit(int id, LvsAccount updatedAccount)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrEmpty(updatedAccount.LvsFullName))
                {
                    ModelState.AddModelError("LvsFullName", "Họ tên là bắt buộc");
                }

                if (string.IsNullOrEmpty(updatedAccount.LvsEmail))
                {
                    ModelState.AddModelError("LvsEmail", "Email là bắt buộc");
                }
                else if (!updatedAccount.LvsEmail.Contains("@"))
                {
                    ModelState.AddModelError("LvsEmail", "Email không hợp lệ");
                }

                if (string.IsNullOrEmpty(updatedAccount.LvsPhone))
                {
                    ModelState.AddModelError("LvsPhone", "Số điện thoại là bắt buộc");
                }
                else if (updatedAccount.LvsPhone.Length < 10 || updatedAccount.LvsPhone.Length > 11)
                {
                    ModelState.AddModelError("LvsPhone", "Số điện thoại phải có 10-11 số");
                }

                if (string.IsNullOrEmpty(updatedAccount.LvsPassword))
                {
                    ModelState.AddModelError("LvsPassword", "Mật khẩu là bắt buộc");
                }
                else if (updatedAccount.LvsPassword.Length < 6)
                {
                    ModelState.AddModelError("LvsPassword", "Mật khẩu phải có ít nhất 6 ký tự");
                }

                if (!ModelState.IsValid)
                {
                    ViewBag.LvsGender = GetGenderOptions(updatedAccount.LvsGender);
                    return View(updatedAccount);
                }

                var existingAccount = _lvsAccounts.FirstOrDefault(a => a.LvsId == id);
                if (existingAccount == null)
                {
                    return NotFound();
                }

                // Update all properties
                existingAccount.LvsFullName = updatedAccount.LvsFullName;
                existingAccount.LvsEmail = updatedAccount.LvsEmail;
                existingAccount.LvsPhone = updatedAccount.LvsPhone;
                existingAccount.LvsAddress = updatedAccount.LvsAddress;
                existingAccount.LvsAvatar = updatedAccount.LvsAvatar;
                existingAccount.LvsBirthday = updatedAccount.LvsBirthday;
                existingAccount.LvsGender = updatedAccount.LvsGender;
                existingAccount.LvsPassword = updatedAccount.LvsPassword;
                existingAccount.LvsFacebook = updatedAccount.LvsFacebook;

                return RedirectToAction(nameof(LvsIndex));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Đã xảy ra lỗi khi cập nhật: {ex.Message}");
                ViewBag.LvsGender = GetGenderOptions(updatedAccount.LvsGender);
                return View(updatedAccount);
            }
        }

        // POST: LvsAccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LvsDelete(int id)
        {
            try
            {
                var account = _lvsAccounts.FirstOrDefault(a => a.LvsId == id);
                if (account == null)
                {
                    return NotFound();
                }

                _lvsAccounts.Remove(account);
                return RedirectToAction(nameof(LvsIndex));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Đã xảy ra lỗi khi xóa tài khoản: {ex.Message}";
                return RedirectToAction(nameof(LvsIndex));
            }
        }

        // Helper method to get gender options
        private List<SelectListItem> GetGenderOptions(string selectedGender = null)
        {
            var options = new List<SelectListItem>
            {
                new SelectListItem { Value = "Nam", Text = "Nam" },
                new SelectListItem { Value = "Nữ", Text = "Nữ" },
                new SelectListItem { Value = "Khác", Text = "Khác" }
            };

            if (selectedGender != null)
            {
                foreach (var option in options)
                {
                    option.Selected = option.Value == selectedGender;
                }
            }

            return options;
        }
    }
}