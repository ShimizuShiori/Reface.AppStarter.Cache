using Reface.AppStarter.Cache;
using Reface.AppStarter.Proxy;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Reface.AppStarter.Attributes
{
    /// <summary>
    /// 读取缓存、或者将结果保存为缓存的特征。
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class CacheAttribute : CacheAttributeBase
    {
        public ICacheRelationshipManager CacheRelationshipManager { get; set; }

        public CacheAttribute()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cacheKeyFormatter">缓存 Key 的 Formatter</param>
        public CacheAttribute(string cacheKeyFormatter) : base(cacheKeyFormatter)
        {
        }

        public override void OnExecuted(ExecutedInfo executedInfo)
        {
            if (executedInfo.Source != ReturnedValueSources.OriginalMethod) return;
            string key = this.GetKeyWithArguments(executedInfo.Method, executedInfo.Arguments);
            this.CachePoolAccessor.Set(key, executedInfo.ReturnedValue);

            IEnumerable<CleanWithAttribute> cleanWithAttributes = executedInfo.Method.GetCustomAttributes<CleanWithAttribute>();
            foreach (var attr in cleanWithAttributes)
            {
                this.CacheRelationshipManager.Register(key, attr);
            }
        }

        public override void OnExecuteError(ExecuteErrorInfo executeErrorInfo)
        {
        }

        public override void OnExecuting(ExecutingInfo executingInfo)
        {
            object result;
            string key = this.GetKeyWithArguments(executingInfo.Method, executingInfo.Arguments);


            if (this.CachePoolAccessor.TryGet(key, out result))
                executingInfo.Return(result);
        }
    }
}
