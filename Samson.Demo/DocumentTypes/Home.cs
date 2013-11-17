using Samson.Services;

namespace Samson.Demo.DocumentTypes
{
    public class Home : Page
    {
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