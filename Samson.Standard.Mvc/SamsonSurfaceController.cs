using Samson.Services;
using Umbraco.Web.Mvc;

namespace Samson.Standard.Mvc
{
    public class SamsonSurfaceController : SurfaceController
    {
        public SamsonSurfaceController()
        {
            StrongContentService = SamsonContext.Current.StrongContentService;
            StrongMediaService = SamsonContext.Current.StrongMediaService;
        }

        public SamsonSurfaceController(IStrongContentService contentService, IStrongMediaService mediaService)
        {
            StrongContentService = contentService;
            StrongMediaService = mediaService;
        }

        /// <summary>
        /// Gets or sets the published content service that allows for strong typing.
        /// </summary>
        /// <value>
        /// The strong content service.
        /// </value>
        protected IStrongContentService StrongContentService { get; set; }

        /// <summary>
        /// Gets or sets the published media service that allows for strong typing.
        /// </summary>
        /// <value>
        /// The strong media service.
        /// </value>
        protected IStrongMediaService StrongMediaService { get; set; }
    }
}
