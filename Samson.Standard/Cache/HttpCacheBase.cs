using System;
using System.Web;

namespace Samson.Standard.Cache
{
    public abstract class HttpCacheBase : ICache
    {
        protected abstract string AddedCacheItemsKey { get; }

        public abstract void Add(string key, object value, int? cacheMinutes = null);

        public void Remove(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }

        public object Retrieve(string key)
        {
            return HttpContext.Current.Cache[key];
        }

        public T Retrieve<T>(string key) where T : class
        {
            return HttpContext.Current.Cache[key] as T;
        }

        public bool Contains(string key)
        {
            return HttpContext.Current.Cache[key] != null;
        }

        public void Clear()
        {
            var addedKeys = Retrieve<string>(AddedCacheItemsKey);

            if (string.IsNullOrWhiteSpace(addedKeys))
            {
                return;
            }

            var keys = addedKeys.Contains(",")
                ? addedKeys.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                : new string[] { addedKeys };

            foreach (var key in keys)
            {
                if (Contains(key))
                {
                    Remove(key);
                }
            }
        }

        protected void AddNewKeyToAddedKeys(string key)
        {
            var addedKeys = Retrieve<string>(AddedCacheItemsKey);

            addedKeys += string.IsNullOrEmpty(addedKeys) ? key : "," + key;

            HttpContext.Current.Cache.Insert(AddedCacheItemsKey, addedKeys, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration);
        }
    }
}
