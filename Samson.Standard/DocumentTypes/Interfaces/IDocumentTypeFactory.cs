using Samson.DocumentTypes;

namespace Samson.Standard.DocumentTypes.Interfaces
{
    public interface IDocumentTypeFactory
    {
        /// <summary>
        /// Gets the node by the integer identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IBasicContentItem GetNodeById(int id);

        /// <summary>
        /// Gets the node by identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        T GetNodeById<T>(int id) where T : class, IBasicContentItem;
    }
}
