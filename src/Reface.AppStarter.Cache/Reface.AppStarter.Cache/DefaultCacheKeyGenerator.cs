
using Reface.AppStarter.Attributes;
using System.Reflection;
using System.Text;

namespace Reface.AppStarter.Cache
{
    [Component]
    public class DefaultCacheKeyGenerator : ICacheKeyGenerator
    {
        public string Generate(MethodInfo methodInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(methodInfo.DeclaringType.FullName);
            sb.Append(".");
            sb.Append(methodInfo.Name);
            sb.Append("(");
            for (int i = 0; i < methodInfo.GetParameters().Length; i++)
            {
                if (i > 0) sb.Append(",");
                sb.Append("{");
                sb.Append(i);
                sb.Append("}");
            }
            sb.Append(")");
            return sb.ToString();
        }
    }
}
