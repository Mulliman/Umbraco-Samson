using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samson.Standard.DocumentTypes;
using Samson.Standard.DocumentTypes.Interfaces;
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
            get { return new DocumentTypeFactory(_umbracoHelper, DocumentTypesProvider); } 
        }
    }
}
