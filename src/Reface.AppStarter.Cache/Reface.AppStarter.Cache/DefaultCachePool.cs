using Reface.AppStarter.Attributes;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;

namespace Reface.AppStarter.Cache
{
    [Component]
    public class DefaultCachePool : ICachePool
    {
        private readonly static ConcurrentDictionary<string, object> cachePool = new ConcurrentDictionary<string, object>();

        public void Clean(string key)
        {
            Debug.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Cache.CLN\t[{key}]");
            object value;
            cachePool.TryRemove(key, out value);
        }

        public void Set(string key, object value)
        {
            Debug.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Cache.SET\t[{key}] = [{value}]");
            cachePool[key] = value;
        }

        public bool TryGet(string key, out object value)
        {
            bool result = cachePool.TryGetValue(key, out value);
            Debug.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Cache.TGT\t[{key}] : {result}");
            return result;
        }
    }
}
