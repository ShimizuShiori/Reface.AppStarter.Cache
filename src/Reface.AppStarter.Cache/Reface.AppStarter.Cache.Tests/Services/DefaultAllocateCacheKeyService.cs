using Reface.AppStarter.Attributes;

namespace Reface.AppStarter.Cache.Tests.Services
{
    [Component]
    public class DefaultAllocateCacheKeyService : IAllocateCacheKeyService
    {
        private int i = 1;
        [Cache("BookOf{0}")]
        public string GetNameById(int id)
        {
            return $"Book_{id}_{i++}";
        }

        [CleanCache("BookOf{0}")]
        public void UpdateNameById(int id)
        {
            i++;
        }
    }
}
