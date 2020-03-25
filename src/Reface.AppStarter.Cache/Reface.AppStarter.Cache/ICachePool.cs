namespace Reface.AppStarter.Cache
{
    public interface ICachePool
    {
        bool TryGet(string key, out object value);

        void Set(string key, object value);

        void Clean(string key);
    }
}
