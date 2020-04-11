using System;

namespace Reface.AppStarter.Attributes
{
    /// <summary>
    /// 连同清除。
    /// 当指定的缓存被清除了，该缓存也会被一同清除。
    /// 一个类上可以指定多个 <see cref="CleanWithAttribute"/>。
    /// 当这些 <see cref="CleanWithAttribute"/> 中任意一个被清除后，当前的缓存也会被清除
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class CleanWithAttribute : Attribute
    {
        public string CacheKey { get; private set; }

        public CleanWithAttribute(string cacheKey)
        {
            CacheKey = cacheKey;
        }
    }
}
