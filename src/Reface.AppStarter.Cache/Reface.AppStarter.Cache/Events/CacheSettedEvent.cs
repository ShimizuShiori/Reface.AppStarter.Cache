namespace Reface.AppStarter.Cache.Events
{
    public class CacheSettedEvent : CacheEvent
    {
        public object Value { get; private set; }

        public CacheSettedEvent(object source, string key, object value) : base(source, key)
        {
            this.Value = value;
        }
    }
}
