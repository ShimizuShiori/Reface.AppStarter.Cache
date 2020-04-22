using System;

namespace Reface.AppStarter.Attributes
{
    /// <summary>
    /// 连同清除。
    /// 当指定的缓存被清除了，该缓存也会被一同清除。
    /// 一个类上可以指定多个 <see cref="CleanWithAttribute"/>。
    /// 当这些 <see cref="CleanWithAttribute"/> 中任意一个被清除后，当前的缓存也会被清除。
    /// 比如，你有个方法是 GetUsesByNameLike(string name) ，你为的结果设置了缓存 UserByNameLike{0}，但是当任意一个 User 信息发生变化时，你都应当删除这些缓存，
    /// 那你可以为 GetUserByNameLike(string name) 添加一个缓存为 [CleanWith("AnyUser")]
    /// 对于任意的 User 的增删改查，你都可以删除 AnyUser。
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class CleanWithAttribute : Attribute
    {
        public string CacheKey { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cacheKey">指定一个 Cache 的 Key。当该缓存被清除后，标记了此特征的方法所产生的缓存也会被一同清除。</param>
        public CleanWithAttribute(string cacheKey)
        {
            CacheKey = cacheKey;
        }
    }
}
