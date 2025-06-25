using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lession10.Models;

namespace Lession10.Controllers
{
    public class LvsPostsController : Controller
    {
        private readonly LvsK23cnt3Lession10Context _context;

        public LvsPostsController(LvsK23cnt3Lession10Context context)
        {
            _context = context;
        }

        // GET: LvsPosts
        public async Task<IActionResult> LvsIndex()
        {
            return View(await _context.LvsPosts.ToListAsync());
        }

        // GET: LvsPosts/Details/5
        public async Task<IActionResult> LvsDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvsPost = await _context.LvsPosts
                .FirstOrDefaultAsync(m => m.Lvsid == id);
            if (lvsPost == null)
            {
                return NotFound();
            }

            return View(lvsPost);
        }

        // GET: LvsPosts/Create
        public IActionResult LvsCreate()
        {
            return View();
        }

        // POST: LvsPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LvsCreate(LvsPost lvsPost)  // Remove [Bind] attribute
        {
            if (ModelState.IsValid)
            {
                if (lvsPost.ImageFile != null && lvsPost.ImageFile.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(lvsPost.ImageFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await lvsPost.ImageFile.CopyToAsync(stream);
                    }

                    lvsPost.LvsImage = "/uploads/" + fileName;
                }

                _context.Add(lvsPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(LvsIndex));
            }
            return View(lvsPost);
        }

        // GET: LvsPosts/Edit/5
        public async Task<IActionResult> LvsEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvsPost = await _context.LvsPosts.FindAsync(id);
            if (lvsPost == null)
            {
                return NotFound();
            }
            return View(lvsPost);
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LvsEdit(int id, LvsPost lvsPost)
        {
            if (id != lvsPost.Lvsid)
            {
                return NotFound();
            }

            // Get the existing post from the database
            var existingPost = await _context.LvsPosts.FindAsync(id);
            if (existingPost == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Handle image upload if a new file was provided
                    if (lvsPost.ImageFile != null && lvsPost.ImageFile.Length > 0)
                    {
                        // Delete old file if exists
                        if (!string.IsNullOrEmpty(existingPost.LvsImage))
                        {
                            var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", existingPost.LvsImage.TrimStart('/'));
                            if (System.IO.File.Exists(oldFilePath))
                            {
                                System.IO.File.Delete(oldFilePath);
                            }
                        }

                        // Save new file
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(lvsPost.ImageFile.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await lvsPost.ImageFile.CopyToAsync(stream);
                        }

                        existingPost.LvsImage = "/uploads/" + fileName;
                    }

                    // Update other properties from the form
                    _context.Entry(existingPost).CurrentValues.SetValues(lvsPost);

                    // Explicitly mark as modified if needed
                    _context.Entry(existingPost).State = EntityState.Modified;

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(LvsIndex));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LvsPostExists(lvsPost.Lvsid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(lvsPost);
        }
        // GET: LvsPosts/Delete/5
        public async Task<IActionResult> LvsDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lvsPost = await _context.LvsPosts
                .FirstOrDefaultAsync(m => m.Lvsid == id);
            if (lvsPost == null)
            {
                return NotFound();
            }

            return View(lvsPost);
        }

        // POST: LvsPosts/Delete/5
        [HttpPost, ActionName("LvsDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lvsPost = await _context.LvsPosts.FindAsync(id);
            if (lvsPost == null)
            {
                return NotFound();
            }

            try
            {
                // Delete the associated image file if it exists
                if (!string.IsNullOrEmpty(lvsPost.LvsImage))
                {
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", lvsPost.LvsImage.TrimStart('/'));
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }

                _context.LvsPosts.Remove(lvsPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(LvsIndex));
            }
            catch (DbUpdateException ex)
            {
                // Log the error (uncomment ex variable name and write a log)
                ModelState.AddModelError("", "Unable to delete post. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }

            return View(lvsPost);
        }
        private bool LvsPostExists(int id)
        {
            return _context.LvsPosts.Any(e => e.Lvsid == id);
        }
    }
}
