using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LucVanSon_231090087_Net.Models;

namespace LucVanSon_231090087_Net.Controllers
{
    public class LvsEmployeesController : Controller
    {
        private readonly LucVanSon2310900087NetContext _context;

        public LvsEmployeesController(LucVanSon2310900087NetContext context)
        {
            _context = context;
        }

        // GET: LvsEmployees
        public async Task<IActionResult> LvsIndex()
        {
            return View(await _context.LvsEmployees.ToListAsync());
        }

        // GET: LvsEmployees/Details/5
        public async Task<IActionResult> LvsDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvsEmployee = await _context.LvsEmployees
                .FirstOrDefaultAsync(m => m.LvsEmpId == id);
            if (lvsEmployee == null)
            {
                return NotFound();
            }

            return View(lvsEmployee);
        }

        // GET: LvsEmployees/Create
        public IActionResult LvsCreate()
        {
            return View();
        }

        // POST: LvsEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LvsCreate([Bind("LvsEmpId,LvsEmpName,LvsEmpStartDate,LvsEmpStats")] LvsEmployee lvsEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lvsEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(LvsIndex));
            }
            return View(lvsEmployee);
        }

        // GET: LvsEmployees/Edit/5
        public async Task<IActionResult> LvsEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvsEmployee = await _context.LvsEmployees.FindAsync(id);
            if (lvsEmployee == null)
            {
                return NotFound();
            }
            return View(lvsEmployee);
        }

        // POST: LvsEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LvsEdit(int id, [Bind("LvsEmpId,LvsEmpName,LvsEmpStartDate,LvsEmpStats")] LvsEmployee lvsEmployee)
        {
            if (id != lvsEmployee.LvsEmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lvsEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LvsEmployeeExists(lvsEmployee.LvsEmpId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(LvsIndex));
            }
            return View(lvsEmployee);
        }

        // GET: LvsEmployees/Delete/5
        public async Task<IActionResult> LvsDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvsEmployee = await _context.LvsEmployees
                .FirstOrDefaultAsync(m => m.LvsEmpId == id);
            if (lvsEmployee == null)
            {
                return NotFound();
            }

            return View(lvsEmployee);
        }

        // POST: LvsEmployees/Delete/5
        [HttpPost, ActionName("LvsDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lvsEmployee = await _context.LvsEmployees.FindAsync(id);
            if (lvsEmployee != null)
            {
                _context.LvsEmployees.Remove(lvsEmployee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(LvsIndex));
        }

        private bool LvsEmployeeExists(int id)
        {
            return _context.LvsEmployees.Any(e => e.LvsEmpId == id);
        }
    }
}
