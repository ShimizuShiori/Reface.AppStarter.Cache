using Reface.AppStarter.Proxy;
using System;

namespace Reface.AppStarter.Attributes
{
    /// <summary>
    /// 清除缓存的特征
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class CleanCacheAttribute : CacheAttributeBase
    {
        public CleanCacheAttribute()
        {
        }

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
