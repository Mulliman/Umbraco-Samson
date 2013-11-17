using System;
using System.Collections.Generic;
using System.Linq;
using Samson.Basic.DocumentTypes;
using Samson.DocumentTypes;
using Samson.Services;
using umbraco.NodeFactory;

namespace Samson.Basic.Services
{
    public class StrongContentService : IStrongContentService
    {
        public StrongContentService(ITypesRepository repo)
        {
            TypeRepository = repo;
        }

        public ITypesRepository TypeRepository { get; set; }

        #region Implementation of IStrongContentService

        /// <summary>
        ///     Gets the current node.
        /// </summary>
        /// <returns>
        ///     Returns the current node as a IBasicContentItem.
        /// </returns>
        public IBasicContentItem GetCurrentNode()
        {
            var current = Node.GetCurrent();
            var currentAlias = current.NodeTypeAlias;

            var type = TypeRepository.GetModelTypeFromAlias(currentAlias);

            if (type != typeof(BasicDocumentType))
            {
                return (BasicDocumentType)Activator.CreateInstance(type, current.Id, this);
            }

            return new BasicDocumentType(current.Id);
        }

        /// <summary>
        ///     Gets the current node.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>
        ///     Returns the current node as a T.
        /// </returns>
        public T GetCurrentNode<T>() where T : IBasicContentItem
        {
            if (typeof(T).IsInterface)
            {
                var node = GetCurrentNode();
                return node is T ? (T)node : default(T);
            }

            var currentId = Node.GetCurrent().Id;

            var instance = (T)Activator.CreateInstance(typeof(T), currentId, this);

            return instance;
        }

        /// <summary>
        ///     Gets the node by id.
        /// </summary>
        /// <param name="nodeId">The node id.</param>
        /// <returns>
        ///     Returns the node by id as a Item.
        /// </returns>
        public IBasicContentItem GetNodeById(int nodeId)
        {
            var current = new Node(nodeId);
            var currentAlias = current.NodeTypeAlias;

            var type = TypeRepository.GetModelTypeFromAlias(currentAlias);

            if (type != typeof(BasicDocumentType))
            {
                return (BasicDocumentType)Activator.CreateInstance(type, current.Id, this);
            }

            return new BasicDocumentType(current.Id);
        }

        /// <summary>
        ///     Gets the node by id.
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// The type to return.
        /// <param name="nodeId">The node id.</param>
        /// <returns>
        ///     Returns the node by id as a T.
        /// </returns>
        public T GetNodeById<T>(int nodeId) where T : IBasicContentItem
        {
            if (typeof(T).IsInterface)
            {
                var node = GetNodeById(nodeId);
                return node is T ? (T)node : default(T);
            }

            var instance = (T)Activator.CreateInstance(typeof(T), nodeId, this);

            return instance;
        }

        /// <summary>
        ///     Gets the node by id if still as string.
        /// </summary>
        /// <param name="nodeId">The node id.</param>
        /// <returns>
        ///     Returns the node by id as a Item.
        /// </returns>
        public IBasicContentItem GetNodeById(string nodeId)
        {
            int id;

            if (!int.TryParse(nodeId, out id))
            {
                throw new ArgumentException("nodeId is not convertable to an integer.", "nodeId");
            }

            return GetNodeById(id);
        }

        /// <summary>
        ///     Gets the node by id if still as string.
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// The type to return.
        /// <param name="nodeId">The node id.</param>
        /// <returns>
        ///     Returns the node by id as a T.
        /// </returns>
        public T GetNodeById<T>(string nodeId) where T : IBasicContentItem
        {
            int id;

            if (!int.TryParse(nodeId, out id))
            {
                throw new ArgumentException("nodeId is not convertable to an integer.", "nodeId");
            }

            return GetNodeById<T>(id);
        }

        /// <summary>
        ///     Gets the nodes by ids.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>
        ///     Returns the nodes by ids as a List{Item}.
        /// </returns>
        public IEnumerable<IBasicContentItem> GetNodesByIds(IEnumerable<int> ids)
        {
            return ids.Select(GetNodeById);
        }

        /// <summary>
        ///     Gets the nodes by ids.
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// The type to return.
        /// <param name="ids">The ids.</param>
        /// <returns>
        ///     Returns the nodes by ids as a List{T}.
        /// </returns>
        public IEnumerable<T> GetNodesByIds<T>(IEnumerable<int> ids) where T : IBasicContentItem
        {
            return ids.Select(GetNodeById).Cast<T>();
        }

        /// <summary>
        ///     Gets the root nodes.
        /// </summary>
        /// <returns>
        ///     Returns the root nodes as a List{Item}.
        /// </returns>
        public IEnumerable<IBasicContentItem> GetRootNodes()
        {
            var service = new Umbraco.Core.Services.ContentService();

            var rootDocIds = service.GetRootContent().Select(r => r.Id);

            return rootDocIds.Select(GetNodeById);
        }

        #endregion
    }
}
