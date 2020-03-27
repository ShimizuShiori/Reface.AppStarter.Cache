# Reface.AppStarter.Cache

## 简介

这是 *Reface.AppStarter* 中的一个 *AppModule*
使用该 *AppModule* 只要给 *method* 加上相应的 *Attribute* 就可以实现以下功能
* 缓存数据
* 直接使用缓存返回数据
* 清除缓存

## 依赖项

* Reface.AppStarter >= 1.2.0-beta.1
* Reface.AppStarter.Proxy >= 1.1.1

## 使用方法

### 向你的 *AppModule* 添加依赖

就和其它所有的 *AppModule* 一样,
需要向你的 *AppModule* 添加依赖。
```csharp
[CacheAppModule]
public class MyAppModule
{

}
```

### 添加 *ComponentScanAppModule* 的依赖

*Reface.AppStarter.Cache* 是通过 *[Reface.AppStarter.Proxy](https://github.com/ShimizuShiori/Reface.AppStarter.Proxy)* 的 *AOP* 功能实现的。
因此，通过 *AOP* 产生的缓存功能必须建立在通过 *autofac* 产生的组件上。

```csharp
[CacheAppModule]
[ComponentScanAppModule]
public class MyAppModule
{

}
```

### 设置缓存 / 读取缓存

通过对方法添加 *CacheAttribute*，
当该方法执行过一次后，就会产生缓存，并且当缓存存在的情况下，不会再执行方法。
```csharp
[Cache]
public User GetById(int id)
{
    // some code here
    return new User()
    {
        // some setter here
    };
}
```
当缓存池中没有该数据的时候，会执行 *GetById* , 并在执行后，将结果存入缓存池。
下次执行时，会直接从缓存池获取结果返回，不再执行方法本身。

**关于缓存的 Key**
缓存池是单例的，缓存的检索是通过 *Key* 完成的。
默认情况下，Key 是下面的形式，来保证唯一性的。
{类型名称}.{方法名称}(参数列表使用逗号间隔)

开发者也可以根据自己的需求自定义缓存 *Key*
```csharp
[Cache("User_{0}")]
public User GetById(int id)
{
    // code here
}
```

*Cache* 接受一个字符型的参数作为其 *KeyFormatter* ，
并以此与具体的参数列表生成 *Cache Key*，
生成的方式是 *String.Format(KeyFormatter, Arguments)* 。

### 清除缓存

我们一般不会考虑对缓存内容的更新。
而是直接将缓存删除，当再次需要它的时候，再重新获取，再缓存。
这里，我们可以使用 *CleanCacheAttribute* 来完成对缓存的清除。

与 *Cache* 中的 *KeyFormatter* 一样，*CleanCache* 需要指定一个 *KeyFormatter* 来让其确定清除指定 *Key* 的缓存。

```csharp
[CleanCache("User_{0}")]
public void Update(int id, User user)
{
    // code here
}
```
当 *User* 发生更新后，不能再从缓存中直接读取了。
因此我们需要清除缓存。

## 替换缓存池

*Reface.AppStarter.Cache* 用 *ConcurrentDictionary* 作用其缓存池，
无法作为高性能缓存池进行使用。

因此，开发者可以自己开发缓存池，覆盖自带的缓存池。
使用 *ReplaceCreator* 可以很容易的覆盖已有的 *ICachePool* 组件。

```csharp
[CacheAppModule]
[ComponenSanAppModule]
public class MyAppModule
{
    [ReplaceCreator]
    public ICachePool GetCachePool()
    {
        return new RedisCachePool();
    }
}
```