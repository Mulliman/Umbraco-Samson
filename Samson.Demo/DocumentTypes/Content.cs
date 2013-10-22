using Samson.Services;

namespace Samson.Demo.DocumentTypes
{
    public class Content : Page
    {
        public Content()
        {
        }

        public Content(int nodeId)
            : base(nodeId)
        {
        }

        public Content(int nodeId, IStrongContentService contentService)
            : base(nodeId, contentService)
        {
        }

        /// <summary>
        /// Gets or sets the main title.
        /// </summary>
        /// <value>
        /// The main title.
        /// </value>
        public string MainContent { get { return GetProperty<string>("mainContent"); } }
    }
}