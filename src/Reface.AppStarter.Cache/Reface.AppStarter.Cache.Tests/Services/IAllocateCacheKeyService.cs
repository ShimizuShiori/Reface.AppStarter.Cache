namespace Reface.AppStarter.Cache.Tests.Services
{
    public interface IAllocateCacheKeyService
    {
        string GetNameById(int id);

        void UpdateNameById(int id);
    }
}
