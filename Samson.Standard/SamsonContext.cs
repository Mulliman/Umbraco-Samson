using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samson.Standard.DocumentTypes.Interfaces;

namespace Samson.Standard
{
    public class SamsonContext
    {
        #region Singleton
        
        static readonly SamsonContext instance = new SamsonContext();

        static SamsonContext() {}

        SamsonContext() 
        {
            DocumentTypeFactory = DocumentTypeFactory;
        }

        public static SamsonContext Current
        {
            get
            {
                return instance;
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets the document type factory.
        /// </summary>
        /// <value>
        /// The document type factory.
        /// </value>
        public IDocumentTypeFactory DocumentTypeFactory { get; set; }
    }
}
