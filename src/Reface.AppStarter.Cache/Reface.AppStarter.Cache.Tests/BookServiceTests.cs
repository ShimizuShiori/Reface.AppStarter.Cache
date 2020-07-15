using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.AppStarter.Attributes;
using Reface.AppStarter.Cache.Tests.Models;
using Reface.AppStarter.Cache.Tests.Services;
using Reface.AppStarter.UnitTests;
using System.Collections.Generic;

namespace Reface.AppStarter.Cache.Tests
{
    [TestClass]
    public class BookServiceTests : TestClassBase<TestAppModule>
    {
        [AutoCreate]
        public IBookService BookService { get; set; }

        protected override void OnAppStarted()
        {
            this.BookService.Clear();
            this.GetCacheInfos().Clear();
        }

        private List<CacheInfo> GetCacheInfos()
        {
            return this.App.Context.GetOrCreate<List<CacheInfo>>("CACHE_INFO", key => new List<CacheInfo>());
        }

        [TestMethod]
        public void CreateAndCleanAllBook()
        {
            this.BookService.Create(new Book(1, "ReadingTree"));
            this.BookService.Create(new Book(2, "LittleFox"));
            var cacheInfos = this.GetCacheInfos();
            Assert.AreEqual(2, cacheInfos.Count);
            Assert.AreEqual(new CacheInfo(CacheActions.Clean, "ALL_BOOK"), cacheInfos[0]);
            Assert.AreEqual(new CacheInfo(CacheActions.Clean, "ALL_BOOK"), cacheInfos[1]);
        }

        [TestMethod]
        public void CreateAndGetTwice()
        {
            this.BookService.Create(new Book(1, "ReadingTree"));
            var book = this.BookService.GetById(1);
            book = this.BookService.GetById(1);
            var cacheInfos = this.GetCacheInfos();
            Assert.AreEqual(3, cacheInfos.Count);
            Assert.AreEqual(new CacheInfo(CacheActions.Clean, "ALL_BOOK"), cacheInfos[0]);
            Assert.AreEqual(new CacheInfo(CacheActions.Set, "BOOK_1"), cacheInfos[1]);
            Assert.AreEqual(new CacheInfo(CacheActions.Hit, "BOOK_1"), cacheInfos[2]);
        }

        [TestMethod]
        public void CreateGetById2TimesAndCreateAndGet()
        {
            this.BookService.Create(new Book(1, "ReadingTree"));
            var book = this.BookService.GetById(1);
            book = this.BookService.GetById(1);
            this.BookService.Create(new Book(2, "LittleFox"));
            book = this.BookService.GetById(1);
            book = this.BookService.GetById(1);

            var cacheInfos = this.GetCacheInfos();

            Assert.AreEqual(6, cacheInfos.Count);
            Assert.AreEqual(new CacheInfo(CacheActions.Clean, "ALL_BOOK"), cacheInfos[0]);
            Assert.AreEqual(new CacheInfo(CacheActions.Set, "BOOK_1"), cacheInfos[1]);
            Assert.AreEqual(new CacheInfo(CacheActions.Hit, "BOOK_1"), cacheInfos[2]);
            Assert.AreEqual(new CacheInfo(CacheActions.Clean, "ALL_BOOK"), cacheInfos[3]);
            Assert.AreEqual(new CacheInfo(CacheActions.Hit, "BOOK_1"), cacheInfos[4]);
            Assert.AreEqual(new CacheInfo(CacheActions.Hit, "BOOK_1"), cacheInfos[5]);
        }

        [TestMethod]
        public void CreateGetById2TimesAndUpdateAndGetById()
        {
            this.BookService.Create(new Book(1, "ReadingTree"));
            var book = this.BookService.GetById(1);
            book = this.BookService.GetById(1);
            this.BookService.Update(1, new Book(1, "RT"));
            book = this.BookService.GetById(1);
            book = this.BookService.GetById(1);

            var cacheInfos = this.GetCacheInfos();
            Assert.AreEqual(6, cacheInfos.Count);
            cacheInfos[0].AssertIs(CacheActions.Clean, "ALL_BOOK");
            cacheInfos[1].AssertIs(CacheActions.Set, "BOOK_1");
            cacheInfos[2].AssertIs(CacheActions.Hit, "BOOK_1");
            cacheInfos[3].AssertIs(CacheActions.Clean, "BOOK_1");
            cacheInfos[4].AssertIs(CacheActions.Set, "BOOK_1");
            cacheInfos[5].AssertIs(CacheActions.Hit, "BOOK_1");
        }

        [TestMethod]
        public void Create2BooksAndClearAll()
        {
            this.BookService.Create(new Book(1, "B1"));
            this.BookService.Create(new Book(2, "B2"));
            var book = this.BookService.GetById(1);
            book = this.BookService.GetById(1);
            book = this.BookService.GetById(2);
            book = this.BookService.GetById(2);
            var books = this.BookService.GetAll();
            books = this.BookService.GetAll();
            this.BookService.Clear();
            book = this.BookService.GetById(1);
            Assert.IsNull(book);
            book = this.BookService.GetById(2);
            Assert.IsNull(book);
            books = this.BookService.GetAll();
            Assert.AreEqual(0, books.Count);

            var caches = this.GetCacheInfos();
            caches[0].AssertIs(CacheActions.Clean, "ALL_BOOK");
            caches[1].AssertIs(CacheActions.Clean, "ALL_BOOK");
            caches[2].AssertIs(CacheActions.Set, "BOOK_1");
            caches[3].AssertIs(CacheActions.Hit, "BOOK_1");
            caches[4].AssertIs(CacheActions.Set, "BOOK_2");
            caches[5].AssertIs(CacheActions.Hit, "BOOK_2");
            caches[6].AssertIs(CacheActions.Set, "ALL_BOOK");
            caches[7].AssertIs(CacheActions.Hit, "ALL_BOOK");
            caches[8].AssertIs(CacheActions.Clean, "EVERY_BOOK");
            caches[9].AssertIs(CacheActions.Clean, "BOOK_1");
            caches[10].AssertIs(CacheActions.Clean, "BOOK_2");
            caches[11].AssertIs(CacheActions.Clean, "ALL_BOOK");
            caches[12].AssertIs(CacheActions.Set, "BOOK_1");
            caches[13].AssertIs(CacheActions.Set, "BOOK_2");
            caches[14].AssertIs(CacheActions.Set, "ALL_BOOK");
            Assert.AreEqual(15, caches.Count);
        }
    }
}
