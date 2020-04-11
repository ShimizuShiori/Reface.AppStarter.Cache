using Reface.AppStarter.Attributes;
using System.Collections.Generic;

namespace Reface.AppStarter.Cache
{
    /// <summary>
    /// 缓存 Key 关联管理器
    /// </summary>
    public interface ICacheRelationshipManager
    {
        IEnumerable<string> GetCacheKeysWillBeRemovedWith(string cacheKey);

        void Register(string cacheKey, CleanWithAttribute attribute);
    }
}
