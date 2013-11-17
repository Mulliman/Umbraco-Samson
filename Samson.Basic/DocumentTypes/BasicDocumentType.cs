using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Samson.Basic.Services;
using Samson.DocumentTypes;
using Samson.Services;
using umbraco.NodeFactory;

namespace Samson.Basic.DocumentTypes
{
    public class BasicDocumentType : Node, IBasicContentItem
    {
        public BasicDocumentType()
        {
        }

        public BasicDocumentType(int nodeId)
            : base(nodeId)
        {
            ContentService = new StrongContentService(new DocumentTypeModelsRepository());
        }

        public BasicDocumentType(int nodeId, IStrongContentService contentService) : base(nodeId)
        {
            if (contentService == null)
            {
                ContentService = new StrongContentService(new DocumentTypeModelsRepository());
            }

            ContentService = contentService;
        }

        public IStrongContentService ContentService { get; set; }

        #region Implementation of IBasicContentItem

        /// <summary>
        ///     Gets the creator id.
        /// </summary>
        /// <value>
        ///     The creator id.
        /// </value>
        public int CreatorId
        {
            get { return CreatorID; }
        }

        /// <summary>
        ///     Gets or sets the parent id.
        /// </summary>
        /// <value>
        ///     The parent id.
        /// </value>
        public int ParentId
        {
            get { return Parent.Id; }
        }

        /// <summary>
        ///     Gets the template.
        /// </summary>
        /// <value>
        ///     The template.
        /// </value>
        public int Template
        {
            get { return template; }
        }

        /// <summary>
        ///     Gets the writer ID.
        /// </summary>
        /// <value>
        ///     The writer ID.
        /// </value>
        public int WriterId
        {
            get { return WriterID; }
        }

        #endregion

        #region Get Children

        /// <summary>
        ///     Gets the child nodes.
        /// </summary>
        /// <returns>
        ///     Returns the child nodes as a List{Item}.
        /// </returns>
        public IEnumerable<IBasicContentItem> GetChildNodes()
        {
            var childIds = ChildrenAsList.Select(c => c.Id);

            return childIds.Any() ? childIds.Select(i => ContentService.GetNodeById(i)) : Enumerable.Empty<IBasicContentItem>();
        }

        /// <summary>
        ///     Gets the child nodes.
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// <returns>
        ///     Returns the child nodes as a List{T}.
        /// </returns>
        public IEnumerable<T> GetChildNodes<T>() where T : IBasicContentItem
        {
            var childIds = ChildrenAsList.Select(c => c.Id);

            var matchingChildren = new List<T>();

            foreach (var id in childIds)
            {
                try
                {
                    var instance = ContentService.GetNodeById<T>(id);
                    if (instance != null)
                    {
                        matchingChildren.Add(instance);
                    }
                }
                catch
                {
                    // is this a good way of checking?
                }
            }

            return matchingChildren;
        }

        #endregion

        #region Get Descendants

        /// <summary>
        ///     Gets the descendant nodes.
        /// </summary>
        /// <returns>The descendant nodes.</returns>
        public IEnumerable<IBasicContentItem> GetDescendantNodes()
        {
            throw new NotImplementedException("Hopefully you shouldn't need to use descendants as it can possibly create a huge performance hit. If we end up needing it we'll implement it.");
        }

        /// <summary>
        ///     Gets the descendant nodes.
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// <returns>The descendant nodes.</returns>
        public IEnumerable<T> GetDescendantNodes<T>() where T : IBasicContentItem
        {
            throw new NotImplementedException("Hopefully you shouldn't need to use descendants as it can possibly create a huge performance hit. If we end up needing it we'll implement it.");
        }

        #endregion

        #region Get Parent

        /// <summary>
        ///     Gets the parent node.
        /// </summary>
        /// <returns>
        ///     Returns the parent as a IBasicContentItem.
        /// </returns>
        public IBasicContentItem GetParentNode()
        {
            return ContentService.GetNodeById(ParentId);
        }

        /// <summary>
        ///     Gets the parent node.
        /// </summary>
        /// <typeparam name="T">The type to return as.</typeparam>
        /// <returns>
        ///     Returns the parent as a T.
        /// </returns>
        public T GetParentNode<T>() where T : IBasicContentItem, new()
        {
            return ContentService.GetNodeById<T>(ParentId);
        }

        #endregion

        #region Get Ancestor

        /// <summary>
        ///     Gets the ancestor node of type.
        /// </summary>
        /// <returns>
        ///     Returns the ancestor node of type as a BasicDocumentType.
        /// </returns>
        public T GetAncestorNodeOfType<T>() where T : class, IBasicContentItem
        {
            if (ParentId == 0 || ParentId == -1)
            {
                return default(T);
            }

            return GetAncestor<T>(ParentId);
        }

        private T GetAncestor<T>(int childId) where T : class, IBasicContentItem
        {
            var node = ContentService.GetNodeById(childId);

            return node is T ? node as T : GetAncestor<T>(node.ParentId);
        }

        #endregion

        /// <summary>
        ///     Gets the property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="contentItem">The content item.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>
        ///     Returns the property.
        /// </returns>
        protected T GetProperty<T>(string propertyName)
        {
            if (!PropertiesAsList.Select(p => p.Alias).Contains(propertyName))
            {
                return default(T);
            }

            try
            {
                var propertyValue = Properties[propertyName].Value;

                TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
                return (T)tc.ConvertFrom(propertyValue);
            }
            catch
            {
                return default(T);
            }
        }
    }
}
