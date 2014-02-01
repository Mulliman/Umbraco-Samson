using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Samson.Standard.DocumentTypes;

namespace Samson.Demo7.DocumentTypes
{
    [DocumentTypeAlias("Page")]
    public class Page : BasicContentItem
    {
        public override void SetCustomFields()
        {
            PageTitle = GetPropertyValue<string>("title");
        }

        public string PageTitle { get; set; }
    }
}