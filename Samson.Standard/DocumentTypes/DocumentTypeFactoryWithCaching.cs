using System.Web;
using Samson.DocumentTypes;
using Samson.Standard.Cache;
using Samson.Standard.DocumentTypes.Interfaces;
using Umbraco.Web;

namespace Samson.Standard.DocumentTypes
{
    public class DocumentTypeFactoryWithCaching : DocumentTypeFactory, IDocumentTypeFactoryWithCaching
    {
        private readonly ICache _cache;
        private const string NodeByIdPrefix = "GetByNodeId_";
        private const string NodeByIdOfTypeFormat = "GetByNodeId_{0}_{1}";

        public DocumentTypeFactoryWithCaching(UmbracoHelper umbracoHelper, IDocumentTypesProvider documentTypesProvider, ICache cache)
            : base (umbracoHelper, documentTypesProvider)
        {
            _cache = cache;
        }

        public override IBasicContentItem GetNodeById(int id)
        {
            
            var cacheKey = NodeByIdPrefix + id;

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
            var cacheKey = string.Format(NodeByIdOfTypeFormat, id, typeof(T).Name);

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

        public void ClearCachedNode(int id)
        {
            // Clear the cached object
            var cacheKey = NodeByIdPrefix + id;

            if (_cache.Contains(cacheKey))
            {
                _cache.Remove(cacheKey);
            }

            // Go through the node specifc ones and delete if needs be.
            var registeredDocTypes = DocumentTypesProvider.GetModelTypesAndAliases();

            foreach (var docType in registeredDocTypes)
            {
                var possibleKey = string.Format(NodeByIdOfTypeFormat, id, docType.Key);

                if (_cache.Contains(possibleKey))
                {
                    _cache.Remove(possibleKey);
                }
            }
        }
    }
}