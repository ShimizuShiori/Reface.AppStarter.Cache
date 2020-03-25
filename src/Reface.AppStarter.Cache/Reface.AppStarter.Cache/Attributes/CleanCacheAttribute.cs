using Reface.AppStarter.Attributes;
using Reface.AppStarter.Proxy;
using System;

namespace Reface.AppStarter.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CleanCacheAttribute : CacheAttributeBase
    {
        public CleanCacheAttribute()
        {
        }

        public CleanCacheAttribute(string cacheKey) : base(cacheKey)
        {
        }

        public override void OnExecuted(ExecutedInfo executedInfo)
        {
            this.CachePool.Clean(this.GetKeyWithArguments(executedInfo.Method, executedInfo.Arguments));
        }

        public override void OnExecuteError(ExecuteErrorInfo executeErrorInfo)
        {
        }

        public override void OnExecuting(ExecutingInfo executingInfo)
        {
        }
    }
}
