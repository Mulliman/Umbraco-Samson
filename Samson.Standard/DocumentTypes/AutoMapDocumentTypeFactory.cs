using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samson.Standard.DocumentTypes.Interfaces;
using Umbraco.Web;

namespace Samson.Standard.DocumentTypes
{
    public class AutoMapDocumentTypeFactory : DocumentTypeFactory
    {
        public AutoMapDocumentTypeFactory(UmbracoHelper umbracoHelper, IDocumentTypesProvider documentTypesProvider)
            : base(umbracoHelper, documentTypesProvider)
        {
        }
    }
}