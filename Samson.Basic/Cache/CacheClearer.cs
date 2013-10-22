using Umbraco.Core;
using Umbraco.Core.Services;

namespace Samson.Basic.Cache
{
    public class CacheClearer : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            ContentTypeService.SavedContentType += ContentTypeService_SavedContentType;
        }

        private void ContentTypeService_SavedContentType(IContentTypeService sender, Umbraco.Core.Events.SaveEventArgs<Umbraco.Core.Models.IContentType> e)
        {
            DocumentModelTypesCache.Instance.ClearCache();
            MediaModelTypesCache.Instance.ClearCache();
        }
    }
}
