using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
                            && t.IsAssignableFrom(typeof(IBasicDocumentType))).ToList();
        }
    }
}
