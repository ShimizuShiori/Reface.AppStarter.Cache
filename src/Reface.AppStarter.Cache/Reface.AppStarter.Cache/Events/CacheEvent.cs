using Reface.EventBus;

namespace Reface.AppStarter.Cache.Events
{
    public class CacheEvent : Event
    {
        public string Key { get; private set; }
        public CacheEvent(object source, string key) : base(source)
        {
            this.Key = key;
        }
    }
}
