using Reface.AppStarter.Attributes;
using Reface.AppStarter.Cache;

namespace Reface.AppStarter.AppModules
{
    /// <summary>
    /// 向 IOC / DI 容器提供 
    /// <see cref="CacheAttribute"/>、 
    /// <see cref="CleanCacheAttribute"/>、
    /// <see cref="CleanWithAttribute"/>
    /// 所需要的组件。
    /// 如果你的模块有类型标记了这些特征，你还需要添加对 <see cref="ProxyAttribute"/> 的依赖。
    /// <see cref="ICachePool"/> 承载了缓存的存储，目前它的实现类是基于内存的。
    /// 你可以使用 <see cref="ReplaceCreatorAttribute"/> 来替换已有的 <see cref="ICachePool"/> 实现类。
    /// <see cref="ICacheRelationshipManager"/> 承载了 <see cref="CleanWithAttribute"/> 的功能，你也可以利用 <see cref="ReplaceCreatorAttribute"/> 替换已有的实现类。
    /// </summary>
    [ComponentScanAppModule]
    public class CacheAppModule : AppModule
    {
    }
}
