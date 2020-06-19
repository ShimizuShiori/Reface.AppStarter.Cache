using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reface.AppStarter.Cache.Tests
{
    public static class AssertExt
    {
        public static void AssertIs(this CacheInfo cacheInfo, CacheActions action, string key)
        {
            Assert.AreEqual(new CacheInfo(action, key), cacheInfo);
        }
    }
}
