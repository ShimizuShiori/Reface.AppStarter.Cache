using Reface.AppStarter.Attributes;
using System.Collections.Generic;

namespace Reface.AppStarter.Cache
{
    /// <summary>
    /// 缓存 Key 关联管理器
    /// </summary>
    public interface ICacheRelationshipManager
    {
        /// <summary>
        /// 根据指定的缓存 Key ，获取所有需要与它一同清除的其它缓存 Key
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        IEnumerable<string> GetCacheKeysWillBeRemovedWith(string cacheKey);

        /// <summary>
        /// 注册一个缓存关联关系
        /// </summary>
        /// <param name="cacheKey">若 B 删除时，A 也需要同时清除。则此处是 A</param>
        /// <param name="attribute">若 B 删除时，A 也需要同时清除。则此处是 B</param>
        void Register(string cacheKey, CleanWithAttribute attribute);
    }
}
