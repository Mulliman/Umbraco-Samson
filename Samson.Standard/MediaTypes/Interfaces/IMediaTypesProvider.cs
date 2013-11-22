using System;
using System.Collections.Generic;

namespace Samson.Standard.MediaTypes.Interfaces
{
    public interface IMediaTypesProvider
    {
        /// <summary>
        /// Gets the Types of the model classes and their respective aliases.
        /// </summary>
        /// <returns></returns>
        IDictionary<string, Type> GetModelTypesAndAliases();

        /// <summary>
        /// Gets the model type from alias. By default we ignore case as it would be nuts to have 2 media types with super similar names so may as well give a little error room.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <param name="stringComparison">The string comparison.</param>
        /// <returns></returns>
        Type GetModelTypeFromAlias(string alias, bool ignoreCase = true);

        /// <summary>
        /// Registers another model.
        /// </summary>
        /// <param name="modelType">Type of the model.</param>
        /// <param name="alias">The alias.</param>
        void RegisterModelType(Type modelType, string alias);

        /// <summary>
        /// Registers a group of model types.
        /// </summary>
        /// <param name="modelsAndAliases">The models and aliases.</param>
        void RegisterModelTypes(IDictionary<string, Type> aliasesAndModelType);
    }
}
