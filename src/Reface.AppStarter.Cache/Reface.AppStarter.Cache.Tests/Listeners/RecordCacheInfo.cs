using Reface.AppStarter.Attributes;
using Reface.AppStarter.Cache.Events;
using Reface.EventBus;
using System.Collections.Generic;

namespace Reface.AppStarter.Cache.Tests.Listeners
{
    [Listener]
    public class RecordCacheInfo : IEventListener<CacheEvent>
    {
        private readonly App app;

        public RecordCacheInfo(App app)
        {
            this.app = app;
        }

        public void Handle(CacheEvent @event)
        {
            List<CacheInfo> cacheInfos = app.Context.GetOrCreate("CACHE_INFO", key => new List<CacheInfo>());
            if (@event is CacheSettedEvent)
            {
                cacheInfos.Add(new CacheInfo(CacheActions.Set, @event.Key));
                return;
            }
            if (@event is CacheClearedEvent)
            {
                cacheInfos.Add(new CacheInfo(CacheActions.Clean, @event.Key));
                return;
            }
            if (@event is CacheHitEvent)
            {
                cacheInfos.Add(new CacheInfo(CacheActions.Hit, @event.Key));
                return;
            }
        }
    }
}
