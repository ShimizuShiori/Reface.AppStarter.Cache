using Reface.AppStarter.Attributes;
using Reface.AppStarter.Cache.Events;
using Reface.EventBus;
using System;

namespace Reface.AppStarter.Cache.Tests.Listeners
{
    [Listener]
    public class ShowCacheKey : IEventListener<CacheEvent>
    {
        public void Handle(CacheEvent @event)
        {
            Console.WriteLine("EventType = {0}, Key = {1}", @event.GetType().Name, @event.Key);
        }
    }
}
