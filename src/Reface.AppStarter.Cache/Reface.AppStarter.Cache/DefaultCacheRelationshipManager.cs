using Reface.AppStarter.Attributes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Reface.AppStarter.Cache
{
    [Component]
    public class DefaultCacheRelationshipManager : ICacheRelationshipManager
    {
        private static readonly ConcurrentDictionary<string, HashSet<string>> cacheKeyToCleanWithCacheKeysMap = new ConcurrentDictionary<string, HashSet<string>>();

        public IEnumerable<string> GetCacheKeysWillBeRemovedWith(string cacheKey)
        {
            HashSet<string> result;
            if (cacheKeyToCleanWithCacheKeysMap.TryGetValue(cacheKey, out result))
                return new List<string>(result);
            return new string[] { };
        }

        public void Register(string cacheKey, CleanWithAttribute attribute)
        {
            Func<string, HashSet<string>> addFunc = key =>
               {
                   return new HashSet<string>() { cacheKey };
               };
            Func<string, HashSet<string>, HashSet<string>> updateFunc = (key, set) =>
                {
                    set.Add(cacheKey);
                    return set;
                };
            cacheKeyToCleanWithCacheKeysMap.AddOrUpdate(
                attribute.CacheKey,
                addFunc,
                updateFunc
            );
        }
    }
}
