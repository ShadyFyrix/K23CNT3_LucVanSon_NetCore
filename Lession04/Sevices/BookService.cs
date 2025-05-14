using System.Collections.Generic;
using System.Linq;
using Lession04.Models;

namespace Lession04.Services
{
    public class BookService
    {
        private static List<LvsBook> _books = new List<LvsBook>
        {
            new LvsBook { Id = 1, Title = "Chi Phèo", Author = "Nam Cao", Category = "Truyện ngắn",ImagePath="/Images/ey.png", Price = 500000, TotalPages = 200 },
            new LvsBook { Id = 2, Title = "Lão Hạc", Author = "Nam Cao", Category = "Truyện ngắn",ImagePath="/Images/eeee.jpg", Price = 700000, TotalPages = 400 },
            new LvsBook { Id = 4, Title = "Conan Phiêu lưu ký", Author = "Aoyama Gosho",ImagePath="/Images/an.png", Category = "Truyện tranh", Price = 550000, TotalPages = 180 },
            new LvsBook { Id = 6, Title = "Đường Xưa Mây Trắng", Author = "Thích Nhất Hạnh",ImagePath="/Images/ey.png", Category = "Tôn giáo", Price = 850000, TotalPages = 500 }
        };

        public List<LvsBook> GetAllBooks() => _books;

        public LvsBook GetLvsBookById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public void AddBook(LvsBook book)
        {
            // Generate new ID
            var newId = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1;
            book.Id = newId;
            _books.Add(book);
        }

        public void UpdateBook(LvsBook book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Category = book.Category;
                existingBook.Price = book.Price;
                existingBook.TotalPages = book.TotalPages;
                existingBook.ImagePath = book.ImagePath;
                existingBook.Description = book.Description;
            }
        }
    }
}