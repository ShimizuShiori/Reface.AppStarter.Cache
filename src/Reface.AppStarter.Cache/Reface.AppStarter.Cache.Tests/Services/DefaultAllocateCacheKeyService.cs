using Reface.AppStarter.Attributes;

namespace Reface.AppStarter.Cache.Tests.Services
{
    [Component]
    public class DefaultAllocateCacheKeyService : IAllocateCacheKeyService
    {
        private int i = 1;
        private int j = 100;

        [Cache("BookOf{0}")]
        public string GetNameById(int id)
        {
            return $"Book_{id}_{i++}";
        }

        [Cache("BookByName_{0}")]
        [CleanWith("BookByName")]
        public int GetByNameLike(string key)
        {
            return j++;
        }

        [CleanCache("BookOf{0}")]
        [CleanCache("BookByName")]
        public void UpdateNameById(int id)
        {
            i++;
        }
    }
}
