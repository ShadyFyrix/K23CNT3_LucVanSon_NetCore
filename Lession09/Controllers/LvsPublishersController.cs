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
    public class LvsPublishersController : Controller
    {
        private readonly LvsBookStoreContext _context;

        public LvsPublishersController(LvsBookStoreContext context)
        {
            _context = context;
        }

        // GET: LvsPublishers
        public async Task<IActionResult> LvsIndex()
        {
            return View(await _context.Publishers.ToListAsync());
        }

        // GET: LvsPublishers/LvsDetails/5
        public async Task<IActionResult> LvsDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(m => m.PublisherId == id);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // GET: LvsPublishers/LvsCreate
        public IActionResult LvsCreate()
        {
            return View();
        }

        // POST: LvsPublishers/LvsCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LvsCreate([Bind("PublisherId,PublisherName,Phone,Address")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publisher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(LvsIndex));
            }
            return View(publisher);
        }

        // GET: LvsPublishers/LvsEdit/5
        public async Task<IActionResult> LvsEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        // POST: LvsPublishers/LvsEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LvsEdit(int id, [Bind("PublisherId,PublisherName,Phone,Address")] Publisher publisher)
        {
            if (id != publisher.PublisherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publisher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LvsPublisherExists(publisher.PublisherId))
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
            return View(publisher);
        }

        // GET: LvsPublishers/LvsDelete/5
        public async Task<IActionResult> LvsDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(m => m.PublisherId == id);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: LvsPublishers/LvsDelete/5
        [HttpPost, ActionName("LvsDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LvsDeleteConfirmed(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(LvsIndex));
        }

        private bool LvsPublisherExists(int id)
        {
            return _context.Publishers.Any(e => e.PublisherId == id);
        }
    }
}