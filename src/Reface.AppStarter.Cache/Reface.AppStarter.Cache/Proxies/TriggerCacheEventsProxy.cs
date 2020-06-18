using Reface.AppStarter.Attributes;
using Reface.AppStarter.Cache.Events;
using Reface.AppStarter.Proxy;
using Reface.AppStarter.Proxy.Attachments;

namespace Reface.AppStarter.Cache.Proxies
{
    [AttachedProxy]
    [CanCastAs(typeof(ICachePool))]
    public class TriggerCacheEventsProxy : IProxy
    {
        private readonly IWork work;

        public TriggerCacheEventsProxy(IWork work)
        {
            this.work = work;
        }

        public void OnExecuted(ExecutedInfo executedInfo)
        {
            if (executedInfo.Method.Name == nameof(ICachePool.Set))
            {
                string key = (string)executedInfo.Arguments[0];
                object value = executedInfo.Arguments[1];
                this.work.PublishEvent(new CacheSettedEvent(this, key, value));
                return;
            }

            if (executedInfo.Method.Name == nameof(ICachePool.Clean))
            {
                string key = (string)executedInfo.Arguments[0];
                this.work.PublishEvent(new CacheClearedEvent(this, key));
                return;
            }

            if (executedInfo.Method.Name == nameof(ICachePool.TryGet))
            {
                bool result = (bool)executedInfo.ReturnedValue;
                string key = (string)executedInfo.Arguments[0];
                if (result)
                    this.work.PublishEvent(new CacheHitEvent(this, key));
                return;
            }
        }

        public void OnExecuteError(ExecuteErrorInfo executeErrorInfo)
        {
        }

        public void OnExecuting(ExecutingInfo executingInfo)
        {
        }
    }
}
