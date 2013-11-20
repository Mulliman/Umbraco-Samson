using System;

namespace Samson.Basic.DocumentTypes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DocumentTypeAttribute : Attribute
    {
        public DocumentTypeAttribute(string documentTypeAlias)
        {

        }

        /// <summary>
        /// Gets or sets the document type alias.
        /// </summary>
        /// <value>
        /// The document type alias.
        /// </value>
        public string DocumentTypeAlias { get; set; }
    }
}
