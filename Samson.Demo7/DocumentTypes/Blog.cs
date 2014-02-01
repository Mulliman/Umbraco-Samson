using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Samson.Standard.DocumentTypes;

namespace Samson.Demo7.DocumentTypes
{
    [DocumentTypeAlias("Blog")]
    public class Blog : Page
    {
        public override void SetCustomFields()
        {
            Tags = GetPropertyValue<string>("tags");

            base.SetCustomFields();
        }

        public string Tags { get; set; }
    }
}