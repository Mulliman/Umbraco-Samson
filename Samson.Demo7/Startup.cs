using System.Reflection;
using System.Web.Mvc;
using Samson.Standard;
using Samson.Standard.DocumentTypes;
using Samson.Standard.MediaTypes;
using Samson.Standard.Services;
using Umbraco.Core;

namespace Samson.Demo7
{
    public class Startup : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            SamsonContext.Current.DocumentTypesProvider = new AttributeDocumentTypeProvider(Assembly.GetExecutingAssembly());
            SamsonContext.Current.StrongContentService = new StrongContentService();

            SamsonContext.Current.MediaTypesProvider = new AttributeMediaTypeProvider(Assembly.GetExecutingAssembly());
            SamsonContext.Current.StrongMediaService = new StrongMediaService();

            ControllerBuilder.Current.SetControllerFactory(
                new Samson.Standard.Mvc.StandardSamsonControllerFactory()
           );
        }
    }
}