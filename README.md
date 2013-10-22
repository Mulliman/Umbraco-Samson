Umbraco-Samson
==============

Named after the Mythological character that was famed being strong, Samson gives the ability to have strongly typed content and media services in Umbraco.

## Hooking up a simple set up

This uses the built in service (which currently needs the Document type to be called the same as the alias.) You can use a custom implementation by implementing the IStrongContentService interface.

### Create the document type

This uses the built in BasicDocumentType, but you can use code-gen, uSiteBuilder models, glass models etc as long as they implement IBasicDocumentType

    using Samson.Basic.DocumentTypes;
    using Samson.Services;

    namespace Samson.Demo.DocumentTypes
    {
        public class Page : BasicDocumentType
        {
            public Page(){}
            public Page(int nodeId) : base(nodeId){}
            public Page(int nodeId, IStrongContentService contentService) : base(nodeId, contentService){}

            public string MainTitle { get { return GetProperty<string>("mainTitle"); } }
        }
    }

### Using the Strong Content Service

This is the most basic way to use the content service

    var contentService = new StrongContentService(new DocumentTypeModelsRepository());

    var page = contentService.GetCurrentNode<Samson.Demo.DocumentTypes.Page>();

    @page.MainTitle