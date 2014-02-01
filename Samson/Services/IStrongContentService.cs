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
        ///     Returns the current node as a IBasicContentItem.
        /// </returns>
        IBasicContentItem GetCurrentNode();

        /// <summary>
        ///     Gets the current node.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>
        ///     Returns the current node as a T.
        /// </returns>
        T GetCurrentNode<T>() where T : class, IBasicContentItem;

        /// <summary>
        ///     Gets the node by id.
        /// </summary>
        /// <param name="nodeId">The node id.</param>
        /// <returns>
        ///     Returns the node by id as a Item.
        /// </returns>
        IBasicContentItem GetNodeById(int nodeId);

        /// <summary>
        ///     Gets the node by id.
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// The type to return.
        /// <param name="nodeId">The node id.</param>
        /// <returns>
        ///     Returns the node by id as a T.
        /// </returns>
        T GetNodeById<T>(int nodeId) where T : class, IBasicContentItem;

        /// <summary>
        /// Gets the nodes by ids.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>
        /// Returns the nodes by ids as a List{Item}.
        /// </returns>
        IEnumerable<IBasicContentItem> GetChildNodes(IBasicContentItem parent);

        /// <summary>
        /// Gets the nodes by ids.
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// <param name="parent">The parent.</param>
        /// <returns>
        /// Returns the nodes by ids as a List{T}.
        /// </returns>
        /// The type to return.
        IEnumerable<T> GetChildNodes<T>(IBasicContentItem parent) where T : class, IBasicContentItem;

        /// <summary>
        /// Gets the child nodes.
        /// </summary>
        /// <param name="parentId">The parent identifier.</param>
        /// <returns></returns>
        IEnumerable<IBasicContentItem> GetChildNodes(int parentId);

        /// <summary>
        /// Gets the child nodes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parentId">The parent identifier.</param>
        /// <returns></returns>
        IEnumerable<T> GetChildNodes<T>(int parentId) where T : class, IBasicContentItem;

        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <param name="child">The child.</param>
        /// <returns></returns>
        IBasicContentItem GetParent(IBasicContentItem child);

        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="child">The child.</param>
        /// <returns></returns>
        T GetParent<T>(IBasicContentItem child) where T : class, IBasicContentItem;

        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <param name="childId">The child identifier.</param>
        /// <returns></returns>
        IBasicContentItem GetParent(int childId);

        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="childId">The child identifier.</param>
        /// <returns></returns>
        T GetParent<T>(int childId) where T : class, IBasicContentItem;

        IEnumerable<IBasicContentItem> GetDescendantNodes(IBasicContentItem parent);

        IEnumerable<T> GetDescendantNodes<T>(IBasicContentItem parent) where T : class, IBasicContentItem;

        IEnumerable<IBasicContentItem> GetDescendantNodes(int parentId);

        IEnumerable<T> GetDescendantNodes<T>(int parentId) where T : class, IBasicContentItem;

        /// <summary>
        ///     Gets the nodes by ids.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>
        ///     Returns the nodes by ids as a List{Item}.
        /// </returns>
        IEnumerable<IBasicContentItem> GetNodesByIds(IEnumerable<int> ids);

        /// <summary>
        ///     Gets the nodes by ids.
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// The type to return.
        /// <param name="ids">The ids.</param>
        /// <returns>
        ///     Returns the nodes by ids as a List{T}.
        /// </returns>
        IEnumerable<T> GetNodesByIds<T>(IEnumerable<int> ids) where T : class, IBasicContentItem;

        /// <summary>
        ///     Gets the root nodes.
        /// </summary>
        /// <returns>
        ///     Returns the root nodes as a List{Item}.
        /// </returns>
        IEnumerable<IBasicContentItem> GetRootNodes();
    }
}
