using Reface.AppStarter.Attributes;
using Reface.AppStarter.Cache.Tests.Models;
using System.Collections.Generic;
using System.Linq;

namespace Reface.AppStarter.Cache.Tests.Services
{
    [Component]
    public class BookService : IBookService
    {
        private static readonly List<Book> allBooks = new List<Book>();

        private Book CopyBook(Book book)
        {
            return new Book() { Id = book.Id, Name = book.Name };
        }

        [CleanCache("ALL_BOOK")]
        public void Create(Book book)
        {
            if (allBooks.Any(x => x.Id == book.Id))
                return;
            allBooks.Add(book);
        }

        [CleanCache("ALL_BOOK")]
        [CleanCache("BOOK_{0}")]
        public void DeleteById(int id)
        {
            var book = allBooks.FirstOrDefault(x => x.Id == id);
            if (book != null)
                allBooks.Remove(book);
        }

        [Cache("ALL_BOOK")]
        public IReadOnlyCollection<Book> GetAll()
        {
            return allBooks.Select(x => CopyBook(x)).ToList();
        }

        [Cache("BOOK_{0}")]
        [CleanWith("EVERY_BOOK")]
        public Book GetById(int id)
        {
            Book book = allBooks.FirstOrDefault(x => x.Id == id);
            if (book == null) return null;
            return CopyBook(book);
        }

        [CleanCache("BOOK_{0}")]
        public void Update(int id, Book newBook)
        {
            Book book = allBooks.FirstOrDefault(x => x.Id == id);
            if (book == null) return;
            book.Name = newBook.Name;
        }

        [CleanCache("EVERY_BOOK")]
        [CleanCache("ALL_BOOK")]
        public void Clear()
        {
            allBooks.Clear();
        }
    }
}
