using System.Reflection;

namespace Reface.AppStarter.Cache
{
    public interface ICacheKeyGenerator
    {
        string Generate(MethodInfo methodInfo);
    }
}
