using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Samson.Basic.DocumentTypes;
using Samson.DocumentTypes;

namespace Samson.Basic.Cache
{
    public class DocumentModelTypesCache : ModelTypesCache
    {
        #region Singleton

        private static readonly DocumentModelTypesCache instance = new DocumentModelTypesCache();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static DocumentModelTypesCache()
        {
        }

        private DocumentModelTypesCache()
        {
        }

        public static DocumentModelTypesCache Instance
        {
            get { return instance; }
        }

        #endregion

        protected override IList<Type> GetTypesFromAssembly()
        {
            return Assembly.GetExecutingAssembly().GetTypes().ToList()
                .Where(t => NamespaceIsInDefinedNamespaces(t.Namespace, AllowedRootNamespaces) 
                            && t.IsAssignableFrom(typeof(IBasicContentItem))).ToList();
        }

        protected override IDictionary<string, Type> GetAliasTypeDictionaryFromAssembly()
        {
            var impliedDocumentTypes = Types.ToDictionary(t => t.Name.ToLower(), t => t);

            var specifiedTypes = Types.Where(t => t.GetCustomAttribute<DocumentTypeAttribute>() != null)
                                      .ToDictionary(t => t.GetCustomAttribute<DocumentTypeAttribute>().DocumentTypeAlias.ToLower(),
                                                    t => t);

            var documentTypes = impliedDocumentTypes;

            foreach (var specifiedType in specifiedTypes)
            {
                // We want specified docTypes to override inferred ones.
                if (documentTypes.ContainsKey(specifiedType.Key))
                {
                    documentTypes.Remove(specifiedType.Key);
                }

                documentTypes.Add(specifiedType.Key, specifiedType.Value);
            }

            return documentTypes;
        }
    }
}
