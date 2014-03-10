using System.Web;
using Samson.DocumentTypes;
using Samson.Standard.Cache;
using Samson.Standard.DocumentTypes.Interfaces;
using Umbraco.Web;

namespace Samson.Standard.DocumentTypes
{
    public class DocumentTypeFactoryWithCaching : DocumentTypeFactory
    {
        private readonly ICache _cache;

        public DocumentTypeFactoryWithCaching(UmbracoHelper umbracoHelper, IDocumentTypesProvider documentTypesProvider, ICache cache)
            : base (umbracoHelper, documentTypesProvider)
        {
            _cache = cache;
        }

        public override IBasicContentItem GetNodeById(int id)
        {
            const string nodeByIdPrefix = "GetByNodeId_";
            var cacheKey = nodeByIdPrefix + id;

            var cached = HttpContext.Current.Cache[cacheKey] as IBasicContentItem;

            if (cached != null)
            {
                return cached;
            }

            var node = base.GetNodeById(id);

            if (node != null)
            {
                _cache.Add(cacheKey, node);
            }

            return node;
        }

        public override T GetNodeById<T>(int id)
        {
            const string nodeByIdPrefix = "GetByNodeId_";
            var cacheKey = nodeByIdPrefix + id + "_" + typeof(T).Name;

            var cached = HttpContext.Current.Cache[cacheKey] as T;

            if (cached != null)
            {
                return cached;
            }

            var node = base.GetNodeById<T>(id);

            if (node != null)
            {
                _cache.Add(cacheKey, node);
            }

            return node;
        }
    }
}