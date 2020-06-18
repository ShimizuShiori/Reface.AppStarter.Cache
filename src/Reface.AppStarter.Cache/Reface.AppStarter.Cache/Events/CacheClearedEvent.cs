namespace Reface.AppStarter.Cache.Events
{
    public class CacheClearedEvent : CacheEvent
    {
        public CacheClearedEvent(object source, string key) : base(source, key)
        {
        }
    }
}
