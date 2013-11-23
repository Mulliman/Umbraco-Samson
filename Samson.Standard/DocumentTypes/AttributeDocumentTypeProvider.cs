﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Samson.DocumentTypes;
using Samson.Standard.DocumentTypes.Interfaces;

namespace Samson.Standard.DocumentTypes
{
    public class AttributeDocumentTypeProvider : IDocumentTypesProvider
    {
        public AttributeDocumentTypeProvider(Assembly assembly)
        {
            // User defined types
            var modelTypes = GetStrongModelTypes(assembly).ToList();

            // Built in types
            modelTypes.AddRange(GetBuiltInSamsonTypes());

            ModelTypesAndAliases = modelTypes.ToDictionary(t => GetAttributeValueOrClassName(t), t => t);
        }

        public AttributeDocumentTypeProvider(IEnumerable<Assembly> assemblies)
        {
            // User defined types
            var modelTypes = assemblies.SelectMany(a => GetStrongModelTypes(a)).ToList();

            // Built in types
            modelTypes.AddRange(GetBuiltInSamsonTypes());

            ModelTypesAndAliases = modelTypes.ToDictionary(t => GetAttributeValueOrClassName(t), t => t);
        }

        private string GetAttributeValueOrClassName(Type type)
        {
            System.Reflection.MemberInfo info = type;
            var attribute = info.GetCustomAttributes()
                .FirstOrDefault(a => a.GetType()
                .Equals(typeof (DocumentTypeAliasAttribute)));

            if(attribute == null)
            {
                // No attribute, just use the class' name
                return type.Name;
            }

            var aliasAttribute = attribute as DocumentTypeAliasAttribute;

            return aliasAttribute != null ? aliasAttribute.Alias : type.Name;
        }

        private IEnumerable<Type> GetBuiltInSamsonTypes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return GetStrongModelTypes(assembly);
        }

        private IEnumerable<Type> GetStrongModelTypes(Assembly assembly)
        {
            return assembly.GetTypes()
                .ToList()
                .Where(t => typeof(IBasicContentItem).IsAssignableFrom(t));
        }

        /// <summary>
        /// Gets or sets the model types and aliases.
        /// </summary>
        /// <value>
        /// The model types and aliases.
        /// </value>
        public IDictionary<string, Type> ModelTypesAndAliases { get; set; }

        /// <summary>
        /// Gets the Types of the model classes and their respective aliases.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IDictionary<string, Type> GetModelTypesAndAliases()
        {
            return ModelTypesAndAliases;
        }

        /// <summary>
        /// Gets the model type from alias. By default we ignore case as it would be nuts to have 2 doc types with super similar names so may as well give a little error room.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Type GetModelTypeFromAlias(string alias, bool ignoreCase = true)
        {
            if (ModelTypesAndAliases.ContainsKey(alias))
            {
                return ModelTypesAndAliases[alias];
            }

            if (ignoreCase)
            {
                var result = ModelTypesAndAliases.FirstOrDefault(m => m.Key.Equals(alias, StringComparison.OrdinalIgnoreCase));

                return !result.Equals(default(KeyValuePair<string, Type>)) ? result.Value : default(Type);
            }

            return default(Type);
        }

        /// <summary>
        /// Registers another model.
        /// </summary>
        /// <param name="modelType">Type of the model.</param>
        /// <param name="alias">The alias.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RegisterModelType(Type modelType, string alias)
        {
            ModelTypesAndAliases.Add(alias, modelType);
        }

        /// <summary>
        /// Registers a group of model types.
        /// </summary>
        /// <param name="modelsAndAliases">The models and aliases.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RegisterModelTypes(IDictionary<string, Type> aliasesAndModelType)
        {
            foreach (var pair in aliasesAndModelType)
            {
                ModelTypesAndAliases.Add(pair);
            }
        }
    }
}