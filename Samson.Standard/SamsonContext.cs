using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samson.Services;
using Samson.Standard.Cache;
using Samson.Standard.DocumentTypes;
using Samson.Standard.DocumentTypes.Interfaces;
using Samson.Standard.MediaTypes;
using Samson.Standard.MediaTypes.Interfaces;
using Umbraco.Web;

namespace Samson.Standard
{
    public class SamsonContext
    {
        #region Singleton
        
        static readonly SamsonContext instance = new SamsonContext();

        static SamsonContext() {}

        SamsonContext() 
        {
            var umbracoContext = UmbracoContext.Current;
            _umbracoHelper = new UmbracoHelper(umbracoContext);
        }

        public static SamsonContext Current
        {
            get
            {
                return instance;
            }
        }

        #endregion

        private UmbracoHelper _umbracoHelper;

        /// <summary>
        /// Gets or sets the document types provider.
        /// </summary>
        /// <value>
        /// The document types provider.
        /// </value>
        public IDocumentTypesProvider DocumentTypesProvider { get; set; }

        /// <summary>
        /// Gets or sets the document type factory.
        /// </summary>
        /// <value>
        /// The document type factory.
        /// </value>
        public IDocumentTypeFactory DocumentTypeFactory 
        {
            get { return new DocumentTypeFactoryWithCaching(_umbracoHelper, DocumentTypesProvider, new SlidingHttpCache(600)); } 
        }

        /// <summary>
        /// Gets the document type factory with caching.
        /// </summary>
        /// <value>
        /// The document type factory with caching.
        /// </value>
        public IDocumentTypeFactoryWithCaching DocumentTypeFactoryWithCaching
        {
            get { return new DocumentTypeFactoryWithCaching(_umbracoHelper, DocumentTypesProvider, new SlidingHttpCache(600)); }
        }

        /// <summary>
        /// Gets or sets the strong content service.
        /// </summary>
        /// <value>
        /// The strong content service.
        /// </value>
        public IStrongContentService StrongContentService { get; set; }

        /// <summary>
        /// Gets or sets the media types provider.
        /// </summary>
        /// <value>
        /// The media types provider.
        /// </value>
        public IMediaTypesProvider MediaTypesProvider { get; set; }

        /// <summary>
        /// Gets or sets the media type factory.
        /// </summary>
        /// <value>
        /// The media type factory.
        /// </value>
        public IMediaTypeFactory MediaTypeFactory
        {
            get { return new MediaTypeFactory(_umbracoHelper, MediaTypesProvider); }
        }

        /// <summary>
        /// Gets or sets the strong media service.
        /// </summary>
        /// <value>
        /// The strong media service.
        /// </value>
        public IStrongMediaService StrongMediaService { get; set; }
    }
}
