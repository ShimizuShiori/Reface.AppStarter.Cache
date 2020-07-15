using Reface.AppStarter.Attributes;
using Reface.AppStarter.Cache.Attachments;
using Reface.AppStarter.Proxy;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reface.AppStarter.Cache.Proxies
{
    [AttachedProxy]
    [HasCache]
    [HasCleanCache]
    public class CacheProxy : IProxy
    {
        private readonly ICacheRelationshipManager cacheRelationshipManager;
        private readonly ICachePoolAccessor cachePoolAccessor;
        private readonly ICacheKeyGenerator cacheKeyGenerator;

        public CacheProxy(ICacheRelationshipManager cacheRelationshipManager, ICachePoolAccessor cachePoolAccessor, ICacheKeyGenerator cacheKeyGenerator)
        {
            this.cacheRelationshipManager = cacheRelationshipManager;
            this.cachePoolAccessor = cachePoolAccessor;
            this.cacheKeyGenerator = cacheKeyGenerator;
        }

        public void OnExecuted(ExecutedInfo executedInfo)
        {
            OnExecutedIfCacheAttributeExists(executedInfo);
            OnExecutedIfCleanCacheAttributeExists(executedInfo);
        }

        public void OnExecuteError(ExecuteErrorInfo executeErrorInfo)
        {
        }

        public void OnExecuting(ExecutingInfo executingInfo)
        {
            OnExecutingIfCacheAttributeExists(executingInfo);
        }

        private void OnExecutingIfCacheAttributeExists(ExecutingInfo info)
        {
            if (info.Method.ReturnType == typeof(void))
                return;

            CacheAttribute cacheAttr = info.Method.GetCustomAttribute<CacheAttribute>();
            if (cacheAttr == null) return;

            string formatter = cacheAttr.CacheKeyFormatter;
            if (string.IsNullOrEmpty(formatter))
                formatter = this.cacheKeyGenerator.Generate(info.Method);

            string key = string.Format(formatter, info.Arguments);

            object result;
            if (!this.cachePoolAccessor.TryGet(key, out result))
                return;

            info.Return(result);
        }
        private void OnExecutedIfCacheAttributeExists(ExecutedInfo info)
        {
            if (info.Method.ReturnType == typeof(void)) return;

            if (info.Source == ReturnedValueSources.Proxy)
                return;

            CacheAttribute cacheAttr = info.Method.GetCustomAttribute<CacheAttribute>();
            if (cacheAttr == null) return;

            string formatter = cacheAttr.CacheKeyFormatter;
            if (string.IsNullOrEmpty(formatter))
                formatter = this.cacheKeyGenerator.Generate(info.Method);

            string key = string.Format(formatter, info.Arguments);

            this.cachePoolAccessor.Set(key, info.ReturnedValue);

            info.Method.GetCustomAttributes<CleanWithAttribute>()
                .ForEach(attr => this.cacheRelationshipManager.Register(key, attr));
        }

        private void OnExecutedIfCleanCacheAttributeExists(ExecutedInfo info)
        {
            IEnumerable<CleanCacheAttribute> cleanCacheAttributes = info.Method.GetCustomAttributes<CleanCacheAttribute>();
            if (!cleanCacheAttributes.Any())
                return;

            cleanCacheAttributes.ForEach(attr =>
            {
                string formatter = attr.CacheKeyFormatter;
                if (string.IsNullOrEmpty(formatter))
                    formatter = this.cacheKeyGenerator.Generate(info.Method);
                string key = string.Format(formatter, info.Arguments);

                this.cachePoolAccessor.Clean(key);
                this.cacheRelationshipManager.GetCacheKeysWillBeRemovedWith(key)
                    .ForEach(x => this.cachePoolAccessor.Clean(x));
            });
        }
    }
}
