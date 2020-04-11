using Reface.EventBus;
using Reface.AppStarter.Attributes;

namespace Reface.AppStarter.Cache.Events
{
    /// <summary>
    /// 缓存被清除后的事件，
    /// 只有通过 <see cref="CleanCacheAttribute"/> 清除缓存时才会触发此事件
    /// </summary>
    public class CacheCleanedEvent : Event
    {
        /// <summary>
        /// 被清除缓存的 Key
        /// </summary>
        public string CacheKey { get; private set; }

        public CacheCleanedEvent(object source, string cacheKey) : base(source)
        {
            this.CacheKey = cacheKey;
        }
    }
}
