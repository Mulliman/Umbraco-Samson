using Samson.Standard.DocumentTypes;
using Samson.Services;

namespace Samson.Demo.DocumentTypes
{
    public class Page : BasicContentItem
    {
        /// <summary>
        /// Gets or sets the main title.
        /// </summary>
        /// <value>
        /// The main title.
        /// </value>
        public string MainTitle { get { return GetPropertyValue<string>("mainTitle"); } }
    }
}