using Reface.AppStarter.Cache;
using Reface.AppStarter.Proxy;
using System;

namespace Reface.AppStarter.Attributes
{
    /// <summary>
    /// 清除缓存的特征
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class CleanCacheAttribute : CacheAttributeBase
    {

        public ICacheRelationshipManager CacheRelationshipManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cacheKeyFormatter">
        /// 相当于是 <see cref="string.Format(string, object[])"/> 中的第一个参数，
        /// 同时会将调用方法的参数列表作为 <see cref="object[]"/> 传入。
        /// 例如：Get(int id, string name)，
        /// 使用 "DemoOf{0}_{1}" 就相当于是 String.Format("DemoOf{0}_{1}", id, name);
        /// </param>
        public CleanCacheAttribute(string cacheKeyFormatter) : base(cacheKeyFormatter)
        {
        }

        public override void OnExecuted(ExecutedInfo executedInfo)
        {
            string cacheKey = this.GetKeyWithArguments(executedInfo.Method, executedInfo.Arguments);
            this.CachePoolAccessor.Clean(cacheKey);
            var keysWillBeMoved = this.CacheRelationshipManager.GetCacheKeysWillBeRemovedWith(cacheKey);
            foreach (var item in keysWillBeMoved)
            {
                this.CachePoolAccessor.Clean(item);
            }
        }

        public override void OnExecuteError(ExecuteErrorInfo executeErrorInfo)
        {
        }

        public override void OnExecuting(ExecutingInfo executingInfo)
        {
        }
    }
}
