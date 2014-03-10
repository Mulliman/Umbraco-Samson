using System.Reflection;
using System.Web.Mvc;
using Samson.Standard;
using Samson.Standard.DocumentTypes;
using Samson.Standard.MediaTypes;
using Samson.Standard.Services;
using Umbraco.Core;
using Umbraco.Core.Services;

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
                new Standard.Mvc.StandardSamsonControllerFactory()
            );

            // As there is caching in the factory it needs to be told if things get published to update the cache.
            ContentService.Published += ContentService_Published;
        }

        static void ContentService_Published(Umbraco.Core.Publishing.IPublishingStrategy sender, Umbraco.Core.Events.PublishEventArgs<Umbraco.Core.Models.IContent> e)
        {
            foreach (var entity in e.PublishedEntities)
            {
                SamsonContext.Current.DocumentTypeFactoryWithCaching.ClearCachedNode(entity.Id);
            }
        }
    }
}