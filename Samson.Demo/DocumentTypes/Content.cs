using Samson.Services;

namespace Samson.Demo.DocumentTypes
{
    public class Content : Page
    {
        /// <summary>
        /// Gets or sets the main title.
        /// </summary>
        /// <value>
        /// The main title.
        /// </value>
        public string MainContent { get { return GetProperty<string>("mainContent"); } }
    }
}