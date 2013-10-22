using Samson.Basic.MediaTypes;
using Samson.Basic.Services;
using Samson.Services;

namespace Samson.Demo.DocumentTypes
{
    public class Home : Page
    {
        public Home()
        {
        }

        public Home(int nodeId)
            : base(nodeId)
        {
        }

        public Home(int nodeId, IStrongContentService contentService)
            : base(nodeId, contentService)
        {
        }

        /// <summary>
        /// Gets the hero image ID.
        /// </summary>
        /// <value>
        /// The hero image ID.
        /// </value>
        public int HeroImageId { get { return GetProperty<int>("heroImage"); } }

        /// <summary>
        /// Gets or sets the main title.
        /// </summary>
        /// <value>
        /// The main title.
        /// </value>
        public string MainContent { get { return GetProperty<string>("mainContent"); } }
    
    }
}