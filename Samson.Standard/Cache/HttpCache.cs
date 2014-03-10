using System;
using System.Web;

namespace Samson.Standard.Cache
{
    public class HttpCache : HttpCacheBase
    {
        private readonly int _expirationMinutes;

        protected override string AddedCacheItemsKey { get { return "AbsoluteCache.AddedKeys"; } }

        public HttpCache()
        {
            _expirationMinutes = 120;
        }

        public HttpCache(int expirationMinutes)
        {
            _expirationMinutes = expirationMinutes;
        }

        public override void Add(string key, object value, int? cacheMinutes = null)
        {
            var mins = cacheMinutes.HasValue && cacheMinutes.Value > 0 ? cacheMinutes : _expirationMinutes;

            var expireDate = DateTime.Now.AddMinutes(mins.Value);

            HttpContext.Current.Cache.Insert(key, value, null, expireDate, System.Web.Caching.Cache.NoSlidingExpiration);
            AddNewKeyToAddedKeys(key);
        }
    }
}