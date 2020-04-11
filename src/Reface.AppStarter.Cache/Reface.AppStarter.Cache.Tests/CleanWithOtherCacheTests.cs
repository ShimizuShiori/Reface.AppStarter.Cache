using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.AppStarter.Attributes;
using Reface.AppStarter.Cache.Tests.Services;
using Reface.AppStarter.UnitTests;

namespace Reface.AppStarter.Cache.Tests
{
    [TestClass]
    public class CleanWithOtherCacheTests : TestClassBase<TestAppModule>
    {
        [AutoCreate]
        public IAllocateCacheKeyService AllocateCacheKeyService { get; set; }

        [TestMethod]
        public void Test()
        {
            int count1 = this.AllocateCacheKeyService.GetByNameLike("a");
            Assert.AreEqual(count1, this.AllocateCacheKeyService.GetByNameLike("a"));

            int count2 = this.AllocateCacheKeyService.GetByNameLike("b");
            Assert.AreNotEqual(count1, count2);
            Assert.AreEqual(count2, this.AllocateCacheKeyService.GetByNameLike("b"));

            this.AllocateCacheKeyService.UpdateNameById(1);

            int count3 = this.AllocateCacheKeyService.GetByNameLike("a");
            Assert.AreNotEqual(count1, count3);

            int count4 = this.AllocateCacheKeyService.GetByNameLike("b");
            Assert.AreNotEqual(count3, count4);
            Assert.AreEqual(count4, this.AllocateCacheKeyService.GetByNameLike("b"));
        }
    }
}
