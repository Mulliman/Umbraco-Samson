using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Samson.DocumentTypes;
using Umbraco.Core.Models;

namespace Samson.Standard.DocumentTypes
{
    public class BasicContentItem : IBasicContentItem
    {
        public virtual void SetCustomFields()
        {
            // Empty as default.
        }

        public IPublishedContent ContentItem { get; set; }

        /// <summary>
        /// Gets or sets the child ids.
        /// </summary>
        /// <value>
        /// The child ids.
        /// </value>
        public IEnumerable<int> ChildIds { get; set; }

        public DateTime CreateDate
        {
            get; set;
        }

        public int CreatorId
        {
            get; set;
        }

        public string CreatorName
        {
            get; set;
        }

        public int Id
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string NiceUrl
        {
            get; set;
        }

        public string NodeTypeAlias
        {
            get; set;
        }

        public int ParentId
        {
            get; set;
        }

        public string Path
        {
            get; set;
        }

        public int SortOrder
        {
            get; set;
        }

        public int Template
        {
            get; set;
        }

        public DateTime UpdateDate
        {
            get; set;
        }

        public string Url
        {
            get; set;
        }

        public Guid Version
        {
            get; set;
        }

        public int WriterId
        {
            get; set;
        }

        public string WriterName
        {
            get; set;
        }

        /// <summary>
        ///     Gets the property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="contentItem">The content item.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>
        ///     Returns the property.
        /// </returns>
        protected T GetPropertyValue<T>(string propertyName)
        {
            try
            {
                var property = ContentItem.GetProperty(propertyName);

                var propertyValue = property.Value;

                if (propertyValue is T)
                {
                    return (T)propertyValue;
                }

                var tc = TypeDescriptor.GetConverter(typeof(T));
                return (T) tc.ConvertFrom(propertyValue);
            }
            catch
            {
                return default(T);
            }
        }
    }
}
