using Microsoft.AspNetCore.Mvc;
using Lession04.Models;
using Lession04.Services;

namespace Lession04.Controllers
{
    public class LvsBookController : Controller
    {
        private readonly BookService _bookService;

        public LvsBookController(BookService bookService)
        {
            _bookService = bookService;
        }

        // GET: LvsBook
        public IActionResult LvsIndex()
        {
            var books = _bookService.GetAllBooks();
            return View(books);
        }

        // GET: LvsBook/LvsCreate
        public IActionResult LvsCreate()
        {
            return View();
        }

        // POST: LvsBook/LvsCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LvsCreate(LvsBook book)
        {
            if (ModelState.IsValid)
            {
                _bookService.AddBook(book);
                return RedirectToAction(nameof(LvsIndex));
            }
            return View(book);
        }

        // GET: LvsBook/LvsEdit/5
        public IActionResult LvsEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetLvsBookById(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: LvsBook/LvsEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LvsEdit(int id, LvsBook book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bookService.UpdateBook(book);
                return RedirectToAction(nameof(LvsIndex));
            }
            return View(book);
        }
    }
}