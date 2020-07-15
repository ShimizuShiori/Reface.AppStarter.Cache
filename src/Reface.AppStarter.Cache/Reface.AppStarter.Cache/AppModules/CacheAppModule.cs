using Reface.AppStarter.Attributes;
using Reface.AppStarter.Cache;
using Reface.AppStarter.AppContainers;

namespace Reface.AppStarter.AppModules
{
    /// <summary>
    /// 向 IOC / DI 容器提供 
    /// <see cref="CacheAttribute"/>、 
    /// <see cref="CleanCacheAttribute"/>、
    /// <see cref="CleanWithAttribute"/>
    /// 所需要的组件。<br />
    /// 该模块会启动 <see cref="ProxyAppModule"/> 以加载与创建 AOP 相关的 <see cref="IAppContainer"/>。 <br />
    /// - <see cref="ICachePool"/> 承载了缓存的存储，目前它的实现类是基于内存的。
    /// 你可以使用 <see cref="ComponentAttribute"/> 替换默认的 <see cref="ICachePool"/> 实现类。<br />
    /// - <see cref="ICacheRelationshipManager"/> 承载了 <see cref="CleanWithAttribute"/> 的功能，你也可以利用 <see cref="ReplaceCreatorAttribute"/> 替换已有的实现类。<br />
    /// - <see cref="ICachePoolAccessor"/> 主要用来访问 <see cref="ICachePool"/> 并抛出一些事件，你可以利用 <see cref="ReplaceCreatorAttribute"/> 替换已有的实现类。
    /// </summary>
    [ComponentScanAppModule]
    [ProxyScanAppModule]
    public class CacheAppModule : AppModule
    {
    }
}
