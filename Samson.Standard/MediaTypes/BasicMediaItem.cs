using System;
using System.ComponentModel;
using Samson.MediaTypes;
using Umbraco.Core.Models;

namespace Samson.Standard.MediaTypes
{
    public class BasicMediaItem : IBasicMediaItem
    {
        public IPublishedContent MediaItem { get; set; }

        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public DateTime CreateDate
        {
            get;
            set;
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
        protected T GetProperty<T>(string propertyName)
        {
            try
            {
                var property = MediaItem.GetProperty(propertyName);

                var propertyValue = property.Value;

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
