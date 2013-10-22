using System;
using System.Linq;
using Samson.Basic.Cache;
using Samson.Basic.DocumentTypes;

namespace Samson.Basic.Services
{
    public class DocumentTypeModelsRepository : ITypesRepository
    {
        protected ModelTypesCache Cache = DocumentModelTypesCache.Instance;

        public Type GetModelTypeFromAlias(string alias)
        {
            alias = alias.ToLower();

            Type typeWithAlias;

            try
            {
                typeWithAlias = Cache.AliasesAndTypes[alias];
            }
            catch (Exception)
            {
                typeWithAlias = Cache.Types.FirstOrDefault(t => t.Name.Equals(alias, StringComparison.OrdinalIgnoreCase));
            }

            return typeWithAlias != default(Type) ? typeWithAlias : typeof(BasicDocumentType);
        }
    }
}
