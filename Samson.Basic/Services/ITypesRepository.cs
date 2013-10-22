using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samson.Basic.Services
{
    public interface ITypesRepository
    {
        /// <summary>
        /// Gets the model type from alias.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <returns></returns>
        Type GetModelTypeFromAlias(string alias);
    }
}
