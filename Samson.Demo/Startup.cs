using System;
using System.Collections.Generic;
using Samson.Demo.DocumentTypes;
using Samson.Standard;
using Samson.Standard.DocumentTypes;
using Umbraco.Core;

namespace Samson.Demo
{
    public class Startup : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            var modelTypes = new Dictionary<string, Type>
                {
                    {"Page", typeof(Page)},
                    {"Content", typeof(Content)},
                    {"blogPage", typeof(BlogPage)},
                    {"Home", typeof(Home)}
                };

            SamsonContext.Current.DocumentTypesProvider = new ManualDocumentTypeProvider();

            SamsonContext.Current.DocumentTypesProvider.RegisterModelTypes(modelTypes);
        }

    }
}