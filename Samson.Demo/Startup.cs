using System;
using System.Collections.Generic;
using System.Reflection;
using Samson.Demo.DocumentTypes;
using Samson.Standard;
using Samson.Standard.DocumentTypes;
using Samson.Standard.MediaTypes;
using Samson.Standard.Services;
using Umbraco.Core;

namespace Samson.Demo
{
    public class Startup : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            //var modelTypes = new Dictionary<string, Type>
            //    {
            //        {"Page", typeof(Page)},
            //        {"Content", typeof(Content)},
            //        {"blogPage", typeof(BlogPage)},
            //        {"Home", typeof(Home)}
            //    };

            //var mediaModelTypes = new Dictionary<string, Type>
            //    {
            //        {"Image", typeof(Image)},
            //        {"File", typeof(File)},
            //        {"Folder", typeof(Folder)}
            //    };

            SamsonContext.Current.DocumentTypesProvider = new AttributeDocumentTypeProvider(Assembly.GetExecutingAssembly());
            //SamsonContext.Current.DocumentTypesProvider.RegisterModelTypes(modelTypes);
            SamsonContext.Current.StrongContentService = new StrongContentService();

            SamsonContext.Current.MediaTypesProvider = new AttributeMediaTypeProvider(Assembly.GetExecutingAssembly());
            //SamsonContext.Current.MediaTypesProvider.RegisterModelTypes(mediaModelTypes);
            SamsonContext.Current.StrongMediaService = new StrongMediaService();
        }

    }
}