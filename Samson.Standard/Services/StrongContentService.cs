using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samson.Services;
using Samson.Standard.DocumentTypes.Interfaces;

namespace Samson.Standard.Services
{
    public class StrongContentService : IStrongContentService
    {
        public IDocumentTypeFactory DocumentTypeFactory { get; set; }

        public StrongContentService()
        {
            DocumentTypeFactory = SamsonContext.Current.DocumentTypeFactory;
        }

        public StrongContentService(IDocumentTypeFactory documentTypeFactory)
        {
            DocumentTypeFactory = documentTypeFactory;
        }

        public Samson.DocumentTypes.IBasicContentItem GetCurrentNode()
        {
            throw new NotImplementedException();
        }

        public T GetCurrentNode<T>() where T : Samson.DocumentTypes.IBasicContentItem
        {
            throw new NotImplementedException();
        }

        public Samson.DocumentTypes.IBasicContentItem GetNodeById(int nodeId)
        {
            throw new NotImplementedException();
        }

        public T GetNodeById<T>(int nodeId) where T : Samson.DocumentTypes.IBasicContentItem
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Samson.DocumentTypes.IBasicContentItem> GetNodesByIds(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetNodesByIds<T>(IEnumerable<int> ids) where T : Samson.DocumentTypes.IBasicContentItem
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Samson.DocumentTypes.IBasicContentItem> GetRootNodes()
        {
            throw new NotImplementedException();
        }
    }
}
