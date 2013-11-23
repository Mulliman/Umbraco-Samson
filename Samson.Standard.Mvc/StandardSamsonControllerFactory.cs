using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Samson.Standard.Mvc
{
    public class StandardSamsonControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            try
            {
                // Create a controller with the samson services if required.
                if (typeof(SamsonSurfaceController).IsAssignableFrom(controllerType))
                {
                    var contentService = SamsonContext.Current.StrongContentService;
                    var mediaService = SamsonContext.Current.StrongMediaService;

                    return Activator.CreateInstance(controllerType, contentService, mediaService) as Controller;
                }

                // Otherwise just use the default constructor.
                return Activator.CreateInstance(controllerType) as Controller;
            }
            catch
            {
                throw new MissingMethodException("The controller can't be created as there is no matching constructor.");
            }
        }
    }
}
