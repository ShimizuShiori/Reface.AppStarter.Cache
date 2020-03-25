using Reface.AppStarter.Proxy;
using System;

namespace Reface.AppStarter.Attributes
{
    /// <summary>
    /// 读取缓存、或者将结果保存为缓存的特征。
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class CacheAttribute : CacheAttributeBase
    {
        public CacheAttribute()
        {
        }

        public CacheAttribute(string cacheKeyFormatter) : base(cacheKeyFormatter)
        {
        }

        public override void OnExecuted(ExecutedInfo executedInfo)
        {
            if (executedInfo.Source != ReturnedValueSources.OriginalMethod) return;
            string key = this.GetKeyWithArguments(executedInfo.Method, executedInfo.Arguments);
            this.CachePool.Set(key, executedInfo.ReturnedValue);
        }

        public override void OnExecuteError(ExecuteErrorInfo executeErrorInfo)
        {
        }

        public override void OnExecuting(ExecutingInfo executingInfo)
        {
            object result;
            string key = this.GetKeyWithArguments(executingInfo.Method, executingInfo.Arguments);
            if (this.CachePool.TryGet(key, out result))
                executingInfo.Return(result);
        }
    }
}
