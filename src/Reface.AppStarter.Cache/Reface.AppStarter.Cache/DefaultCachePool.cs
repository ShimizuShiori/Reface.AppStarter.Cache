using Reface.AppStarter.Attributes;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Reface.AppStarter.Cache
{
    [Component]
    public class DefaultCachePool : ICachePool
    {
        private readonly static ConcurrentDictionary<string, object> cachePool = new ConcurrentDictionary<string, object>();

        public void Clean(string key)
        {
            Debug.WriteLine("Cache.Clean");
            Debug.WriteLine($"\tkey = {key}");
            object value;
            cachePool.TryRemove(key, out value);
        }

        public void Set(string key, object value)
        {
            Debug.WriteLine("Cache.Set");
            Debug.WriteLine($"\tkey = {key}");
            Debug.WriteLine($"\tvalue = {value}");
            cachePool[key] = value;
        }

        public bool TryGet(string key, out object value)
        {
            Debug.WriteLine("Cache.TryGet");
            Debug.WriteLine($"\tkey = {key}");
            return cachePool.TryGetValue(key, out value);
        }
    }
}
