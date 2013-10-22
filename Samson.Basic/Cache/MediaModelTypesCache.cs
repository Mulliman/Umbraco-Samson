using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Samson.MediaTypes;

namespace Samson.Basic.Cache
{
    public class MediaModelTypesCache : ModelTypesCache
    {
        #region Singleton

        private static readonly MediaModelTypesCache instance = new MediaModelTypesCache();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static MediaModelTypesCache()
        {
        }

        private MediaModelTypesCache()
        {
        }

        public static MediaModelTypesCache Instance
        {
            get { return instance; }
        }

        #endregion

        protected override IList<Type> GetTypesFromAssembly()
        {
            return Assembly.GetExecutingAssembly().GetTypes().ToList()
                .Where(t => NamespaceIsInDefinedNamespaces(t.Namespace, AllowedRootNamespaces)
                            && t.IsAssignableFrom(typeof(IBasicMediaType))).ToList();
        }
    }
}
