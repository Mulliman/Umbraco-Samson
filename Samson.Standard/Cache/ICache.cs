namespace Samson.Standard.Cache
{
    public interface ICache
    {
        void Add(string key, object value, int? cacheMinutes = null);

        void Remove(string key);

        object Retrieve(string key);

        T Retrieve<T>(string key) where T : class;

        bool Contains(string key);

        void Clear();
    }
}