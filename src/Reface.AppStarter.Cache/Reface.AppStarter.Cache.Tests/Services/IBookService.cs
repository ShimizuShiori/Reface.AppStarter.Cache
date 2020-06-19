using Reface.AppStarter.Cache.Tests.Models;
using System.Collections.Generic;

namespace Reface.AppStarter.Cache.Tests.Services
{
    public interface IBookService
    {
        void Create(Book book);

        Book GetById(int id);

        IReadOnlyCollection<Book> GetAll();
        void Update(int id, Book newBook);
        void DeleteById(int id);
        void Clear();
    }
}
