using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Samson.Basic.Cache
{
    public abstract class ModelTypesCache
    {
        protected IList<Type> _types;
        protected IDictionary<string, Type> _aliasTypeDictionary;

        public IEnumerable<string> AllowedRootNamespaces { get { return new List<string> { "Samson" }; } }

        public IList<Type> Types { get { return _types ?? (_types = GetTypesFromAssembly()); } }
        public IDictionary<string, Type> AliasesAndTypes { get { return _aliasTypeDictionary ?? (_aliasTypeDictionary = GetAliasTypeDictionaryFromAssembly()); } }

        public virtual void ClearCache()
        {
            _types = null;
            _aliasTypeDictionary = null;
        }

        protected virtual IList<Type> GetTypesFromAssembly()
        {
            return Assembly.GetExecutingAssembly().GetTypes().ToList().Where(t => NamespaceIsInDefinedNamespaces(t.Namespace, AllowedRootNamespaces)).ToList();
        }

        protected virtual IDictionary<string, Type> GetAliasTypeDictionaryFromAssembly()
        {
            return Types.ToDictionary(t => t.Name.ToLower(), t => t);
        }

        protected virtual bool NamespaceIsInDefinedNamespaces(string n, IEnumerable<string> namespaces)
        {
            if (namespaces == null || !namespaces.Any() || !namespaces.Any(string.IsNullOrEmpty))
            {
                return true;
            }

            if (string.IsNullOrEmpty(n))
            {
                return false;
            }

            foreach (var ns in namespaces)
            {
                if (n.Contains(ns))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
