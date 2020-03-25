using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.AppStarter.Cache.Tests.Services;
using Reface.AppStarter.UnitTests;

namespace Reface.AppStarter.Cache.Tests
{
    [TestClass]
    public class AutoCacheKeyServiceTests : TestClassBase<TestAppModule>
    {
        [TestMethod]
        public void GetValueAlwayIsOne()
        {
            IAutoCacheKeyService service = this.ComponentContainer.CreateComponent<IAutoCacheKeyService>();
            Assert.AreEqual(1, service.GetValue());
            Assert.AreEqual(1, service.GetValue());
            Assert.AreEqual(1, service.GetValue());
            Assert.AreEqual(1, service.GetValue());
            Assert.AreEqual(1, service.GetValue());
            Assert.AreEqual(1, service.GetValue());
        }
    }
}
