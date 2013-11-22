using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samson.DocumentTypes;
using Samson.MediaTypes;
using Samson.Standard.MediaTypes.Interfaces;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Samson.Standard.MediaTypes
{
    public class MediaTypeFactory : IMediaTypeFactory
    {
        public MediaTypeFactory(UmbracoHelper umbracoHelper, IMediaTypesProvider mediaTypesProvider)
        {
            UmbracoHelper = umbracoHelper;
            MediaTypesProvider = mediaTypesProvider;
        }

        /// <summary>
        /// Gets or sets the content service.
        /// </summary>
        /// <value>
        /// The content service.
        /// </value>
        protected UmbracoHelper UmbracoHelper { get; set; }

        /// <summary>
        /// Gets or sets the media types provider.
        /// </summary>
        /// <value>
        /// The media types provider.
        /// </value>
        protected IMediaTypesProvider MediaTypesProvider { get; set; }

        /// <summary>
        /// Gets the media item by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IBasicMediaItem GetMediaItemById(int id)
        {
            if(id < 1)
            {
                // Not a valid node ID.
                return null;
            }

            IPublishedContent contentItem = UmbracoHelper.Media(id);

            if(contentItem == null)
            {
                // No node with this id.
                return null;
            }

            var alias = contentItem.DocumentTypeAlias;

            var type = MediaTypesProvider.GetModelTypeFromAlias(alias);

            return CreateModel<BasicMediaItem>(type, contentItem);
        }

        public T GetMediaItemById<T>(int id) where T : class, IBasicMediaItem
        {
            if (id < 1)
            {
                // Not a valid node ID.
                return default(T);
            }

            IPublishedContent contentItem = UmbracoHelper.Media(id);

            if (contentItem == null)
            {
                // No node with this id.
                return default(T);
            }

            var alias = contentItem.DocumentTypeAlias;

            var type = MediaTypesProvider.GetModelTypeFromAlias(alias);

            if (typeof(T).IsAssignableFrom(type))
            {
                return CreateModel<T>(type, contentItem);
            }

            return default(T);
        }

        /// <summary>
        /// Creates the model for the media item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <param name="contentItem">The content item.</param>
        /// <returns></returns>
        protected T CreateModel<T>(Type type, IPublishedContent contentItem) where T : class, IBasicMediaItem
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
        protected T AddStandardUmbracoPropertiesToModel<T>(T model, IPublishedContent contentItem) where T : class, IBasicMediaItem
        {
            model.CreateDate = contentItem.CreateDate;
            model.Id = contentItem.Id;
            model.Name = contentItem.Name;

            // If this uses the built in base class then we'll add the content item as a property
            // to be used in the getters for the user specified fields. 
            var standardModel = model as BasicMediaItem;

            if (standardModel != null)
            {
                standardModel.MediaItem = contentItem;
                return standardModel as T;
            }

            return model;
        }
    }
}
