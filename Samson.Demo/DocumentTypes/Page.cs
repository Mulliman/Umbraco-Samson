using Samson.Basic.DocumentTypes;
using Samson.Services;

namespace Samson.Demo.DocumentTypes
{
    public class Page : BasicDocumentType
    {
        public Page()
        {
        }

        public Page(int nodeId)
            : base(nodeId)
        {
        }

        public Page(int nodeId, IStrongContentService contentService) : base(nodeId, contentService)
        {
        }

        /// <summary>
        /// Gets or sets the main title.
        /// </summary>
        /// <value>
        /// The main title.
        /// </value>
        public string MainTitle { get { return GetProperty<string>("mainTitle"); } }
    }
}