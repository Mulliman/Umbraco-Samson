using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Samson.Demo.DocumentTypes;
using Samson.Standard;

namespace Samson.Demo.App_Start
{
    public class SamsonConfig
    {
        public static void SetUp()
        {
            var modelTypes = new Dictionary<string, Type>
                {
                    {"page", typeof(Page)},
                    {"content", typeof(Content)},
                    {"blogPage", typeof(BlogPage)},
                    {"home", typeof(Home)}
                };

            SamsonContext.Current.DocumentTypesProvider.RegisterModelTypes(modelTypes);
        }
    }
}