using Reface.AppStarter.Attributes;
using Reface.AppStarter.Cache.Events;

namespace Reface.AppStarter.Cache
{
    [Component]
    public class DefaultCachePoolAccessor : ICachePoolAccessor
    {
        private readonly ICachePool cachePool;
        private readonly IWork work;

        public DefaultCachePoolAccessor(IWork work)
        {
            this.work = work;
            ICachePool pool;
            if (!work.TryCreateComponent<ICachePool>(out pool))
                pool = new DefaultCachePool();
            this.cachePool = pool;
        }

        public void Clean(string key)
        {
            this.cachePool.Clean(key);
            work.PublishEvent(new CacheClearedEvent(this, key));
        }

        public void Set(string key, object value)
        {
            this.cachePool.Set(key, value);
            work.PublishEvent(new CacheSettedEvent(this, key, value));
        }

        public bool TryGet(string key, out object value)
        {
            bool result = this.cachePool.TryGet(key, out value);
            if (result)
                work.PublishEvent(new CacheHitEvent(this, key));
            return result;
        }
    }
}
