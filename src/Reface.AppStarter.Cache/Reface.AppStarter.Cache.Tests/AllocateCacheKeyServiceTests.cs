using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.AppStarter.Cache.Tests.Services;
using Reface.AppStarter.UnitTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reface.AppStarter.Cache.Tests
{
    [TestClass]
    public class AllocateCacheKeyServiceTests : TestClassBase<TestAppModule>
    {
        [TestMethod]
        public void Test()
        {
            IAllocateCacheKeyService service = this.ComponentContainer.CreateComponent<IAllocateCacheKeyService>();
            string name = service.GetNameById(1);
            Assert.AreEqual(name, service.GetNameById(1));
            Assert.AreEqual(name, service.GetNameById(1));
            Assert.AreEqual(name, service.GetNameById(1));
            Assert.AreEqual(name, service.GetNameById(1));
            Assert.AreEqual(name, service.GetNameById(1));
            Assert.AreEqual(name, service.GetNameById(1));
            service.UpdateNameById(1);
            string name2 = service.GetNameById(1);
            Assert.AreNotEqual(name, name2);
        }
    }
}
