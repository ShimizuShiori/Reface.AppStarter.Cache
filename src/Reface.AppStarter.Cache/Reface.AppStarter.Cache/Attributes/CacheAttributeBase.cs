using Reface.AppStarter.Cache;
using System.Diagnostics;
using System.Reflection;

namespace Reface.AppStarter.Attributes
{
    public abstract class CacheAttributeBase : ProxyAttribute
    {
        public CacheAttributeBase() : this("")
        {

        }

        public CacheAttributeBase(string cacheKeyFormatter)
        {
            this.CacheKeyFormatter = cacheKeyFormatter;
        }

        /// <summary>
        /// 注入属性，不需要从外部赋值
        /// </summary>
        public ICachePool CachePool { get; set; }

        /// <summary>
        /// 注入属性，不需要从外部赋值
        /// </summary>
        public ICacheKeyGenerator CacheKeyGenerator { get; set; }

        public string CacheKeyFormatter { get; private set; }

        protected string GetKeyWithArguments(MethodInfo methodInfo, object[] arguments)
        {
            if (string.IsNullOrEmpty(this.CacheKeyFormatter))
                this.CacheKeyFormatter = this.CacheKeyGenerator.Generate(methodInfo);
            Debug.WriteLine($"CacheKeyFormatter = {CacheKeyFormatter}");
            return string.Format(this.CacheKeyFormatter, arguments);
        }
    }
}
