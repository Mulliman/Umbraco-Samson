using System.Collections.Generic;
using Samson.DocumentTypes;

namespace Samson.Services
{
    public interface IStrongContentService
    {
        /// <summary>
        ///     Gets the current node.
        /// </summary>
        /// <returns>
        ///     Returns the current node as a IBasicDocumentType.
        /// </returns>
        IBasicDocumentType GetCurrentNode();

        /// <summary>
        ///     Gets the current node.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>
        ///     Returns the current node as a T.
        /// </returns>
        T GetCurrentNode<T>() where T : IBasicDocumentType;

        /// <summary>
        ///     Gets the node by id.
        /// </summary>
        /// <param name="nodeId">The node id.</param>
        /// <returns>
        ///     Returns the node by id as a Item.
        /// </returns>
        IBasicDocumentType GetNodeById(int nodeId);

        /// <summary>
        ///     Gets the node by id.
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// The type to return.
        /// <param name="nodeId">The node id.</param>
        /// <returns>
        ///     Returns the node by id as a T.
        /// </returns>
        T GetNodeById<T>(int nodeId) where T : IBasicDocumentType;

        /// <summary>
        ///     Gets the node by id if still as string.
        /// </summary>
        /// <param name="nodeId">The node id.</param>
        /// <returns>
        ///     Returns the node by id as a Item.
        /// </returns>
        IBasicDocumentType GetNodeById(string nodeId);

        /// <summary>
        ///     Gets the node by id if still as string.
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// The type to return.
        /// <param name="nodeId">The node id.</param>
        /// <returns>
        ///     Returns the node by id as a T.
        /// </returns>
        T GetNodeById<T>(string nodeId) where T : IBasicDocumentType;

        /// <summary>
        ///     Gets the nodes by ids.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>
        ///     Returns the nodes by ids as a List{Item}.
        /// </returns>
        IEnumerable<IBasicDocumentType> GetNodesByIds(IEnumerable<int> ids);

        /// <summary>
        ///     Gets the nodes by ids.
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// The type to return.
        /// <param name="ids">The ids.</param>
        /// <returns>
        ///     Returns the nodes by ids as a List{T}.
        /// </returns>
        IEnumerable<T> GetNodesByIds<T>(IEnumerable<int> ids) where T : IBasicDocumentType;

        /// <summary>
        ///     Gets the root nodes.
        /// </summary>
        /// <returns>
        ///     Returns the root nodes as a List{Item}.
        /// </returns>
        IEnumerable<IBasicDocumentType> GetRootNodes();
    }
}
