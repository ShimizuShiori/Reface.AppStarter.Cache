using Reface.EventBus;

namespace Reface.AppStarter.Cache.Events
{
    public class CacheHitEvent : CacheEvent
    {
        public CacheHitEvent(object source, string key) : base(source, key)
        {
        }
    }
}
