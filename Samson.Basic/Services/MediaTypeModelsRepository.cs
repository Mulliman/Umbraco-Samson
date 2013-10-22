using System;
using System.Linq;
using Samson.Basic.Cache;
using Samson.Basic.MediaTypes;

namespace Samson.Basic.Services
{
    public class MediaTypeModelsRepository : ITypesRepository
    {
        protected ModelTypesCache Cache = MediaModelTypesCache.Instance;

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

            return typeWithAlias != default(Type) ? typeWithAlias : typeof(BasicMediaType);
        }
    }
}
