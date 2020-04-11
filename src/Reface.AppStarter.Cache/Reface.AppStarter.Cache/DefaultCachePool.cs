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
            Console.WriteLine($"[{Thread.CurrentThread.Name}] Cache.CLN\t[{key}]");
            object value;
            cachePool.TryRemove(key, out value);
        }

        public void Set(string key, object value)
        {
            Console.WriteLine($"[{Thread.CurrentThread.Name}] Cache.SET\t[{key}] = [{value}]");
            cachePool[key] = value;
        }

        public bool TryGet(string key, out object value)
        {
            bool result = cachePool.TryGetValue(key, out value);
            Console.WriteLine($"[{Thread.CurrentThread.Name}] Cache.TGT\t[{key}] : {result}");
            return result;
        }
    }
}
