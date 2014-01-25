using System;
using System.Linq;
using Samson.DocumentTypes;
using Samson.Standard.DocumentTypes.Interfaces;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Samson.Standard.DocumentTypes
{
    public class DocumentTypeFactory : IDocumentTypeFactory
    {
        public DocumentTypeFactory(UmbracoHelper umbracoHelper, IDocumentTypesProvider documentTypesProvider)
        {
            UmbracoHelper = umbracoHelper;
            DocumentTypesProvider = documentTypesProvider;
        }

        /// <summary>
        /// Gets or sets the content service.
        /// </summary>
        /// <value>
        /// The content service.
        /// </value>
        protected UmbracoHelper UmbracoHelper { get; set; }

        /// <summary>
        /// Gets or sets the document types provider.
        /// </summary>
        /// <value>
        /// The document types provider.
        /// </value>
        protected IDocumentTypesProvider DocumentTypesProvider { get; set; }

        /// <summary>
        /// Gets the node by the integer identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IBasicContentItem GetNodeById(int id)
        {
            if(id < 1)
            {
                // Not a valid node ID.
                return null;
            }

            IPublishedContent contentItem = UmbracoHelper.Content(id);

            if(contentItem == null)
            {
                // No node with this id.
                return null;
            }

            var alias = contentItem.DocumentTypeAlias;

            var type = DocumentTypesProvider.GetModelTypeFromAlias(alias);

            return CreateModel<BasicContentItem>(type, contentItem);
        }

        /// <summary>
        /// Gets the node by identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public T GetNodeById<T>(int id) where T : class, IBasicContentItem
        {
            if (id < 1)
            {
                // Not a valid node ID.
                return default(T);
            }

            IPublishedContent contentItem = UmbracoHelper.Content(id);

            if (contentItem == null)
            {
                // No node with this id.
                return default(T);
            }

            var alias = contentItem.DocumentTypeAlias;

            var type = DocumentTypesProvider.GetModelTypeFromAlias(alias);

            if (typeof(T).IsAssignableFrom(type))
            {
                return CreateModel<T>(type, contentItem);
            }

            return default(T);
        }

        /// <summary>
        /// Creates the model for the content item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <param name="contentItem">The content item.</param>
        /// <returns></returns>
        protected T CreateModel<T>(Type type, IPublishedContent contentItem) where T : class, IBasicContentItem
        {
            var model = (T) Activator.CreateInstance(type);

            model = AddStandardUmbracoPropertiesToModel(model, contentItem);

            return model;
        }

        /// <summary>
        /// Adds the standard umbraco properties to model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">The model.</param>
        /// <param name="contentItem">The content item.</param>
        /// <returns></returns>
        protected T AddStandardUmbracoPropertiesToModel<T>(T model, IPublishedContent contentItem) where T : class, IBasicContentItem
        {
            model.ChildIds = contentItem.Children.Select(c => c.Id);
            model.CreateDate = contentItem.CreateDate;
            model.CreatorId = contentItem.CreatorId;
            model.CreatorName = contentItem.CreatorName;
            model.Id = contentItem.Id;
            model.Name = contentItem.Name;
            model.NiceUrl = contentItem.Url;
            model.NodeTypeAlias = contentItem.DocumentTypeAlias;
            model.ParentId = contentItem.Parent != null ? contentItem.Parent.Id : 0;
            model.Path = contentItem.Path;
            model.SortOrder = contentItem.SortOrder;
            model.Template = contentItem.TemplateId;
            model.UpdateDate = contentItem.UpdateDate;
            model.Url = contentItem.Url;
            model.Version = contentItem.Version;
            model.WriterId = contentItem.WriterId;
            model.WriterName = contentItem.WriterName;

            // If this uses the built in base class then we'll add the content item as a property
            // to be used in the getters for the user specified fields. 
            var standardModel = model as BasicContentItem;

            if (standardModel != null)
            {
                standardModel.ContentItem = contentItem;

                standardModel.SetCustomFields();

                return standardModel as T;
            }

            return model;
        }
    }
}
