namespace Reface.AppStarter.Cache.Tests.Services
{
    public interface IAllocateCacheKeyService
    {
        string GetNameById(int id);
        int GetByNameLike(string key);
        void UpdateNameById(int id);
    }
}
