using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lession09.Models;

namespace Lession09.Controllers
{
    public class LvsCategoriesController : Controller
    {
        private readonly LvsBookStoreContext _context;

        public LvsCategoriesController(LvsBookStoreContext context)
        {
            _context = context;
        }

        // GET: LvsCategories
        public async Task<IActionResult> LvsIndex()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: LvsCategories/LvsDetails/5
        public async Task<IActionResult> LvsDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: LvsCategories/LvsCreate
        public IActionResult LvsCreate()
        {
            return View();
        }

        // POST: LvsCategories/LvsCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LvsCreate([Bind("CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(LvsIndex));
            }
            return View(category);
        }

        // GET: LvsCategories/LvsEdit/5
        public async Task<IActionResult> LvsEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: LvsCategories/LvsEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LvsEdit(int id, [Bind("CategoryId,CategoryName")] Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LvsCategoryExists(category.CategoryId))
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
            return View(category);
        }

        // GET: LvsCategories/LvsDelete/5
        public async Task<IActionResult> LvsDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: LvsCategories/LvsDelete/5
        [HttpPost, ActionName("LvsDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LvsDeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(LvsIndex));
        }

        private bool LvsCategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }
    }
}