using Reface.AppStarter.Attributes;

namespace Reface.AppStarter.Cache.Tests.Services
{
    [Component]
    public class DefaultAutoCacheKeyService : IAutoCacheKeyService
    {
        private int i = 1;

        [Cache]
        public int GetValue()
        {
            return i++;
        }
    }
}
