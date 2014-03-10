using System.Collections.Generic;
using System.Linq;
using Samson.DocumentTypes;
using Samson.Services;
using Samson.Standard.DocumentTypes.Interfaces;
using umbraco.NodeFactory;
using Umbraco.Web;

namespace Samson.Standard.Services
{
    public class StrongContentService : IStrongContentService
    {
        public IDocumentTypeFactory DocumentTypeFactory { get; set; }

        private readonly UmbracoContext _umbracoContext;

        public StrongContentService()
        {
            DocumentTypeFactory = SamsonContext.Current.DocumentTypeFactory;
            _umbracoContext = UmbracoContext.Current;
        }

        public StrongContentService(IDocumentTypeFactory documentTypeFactory)
        {
            DocumentTypeFactory = documentTypeFactory;
            _umbracoContext = UmbracoContext.Current;
        }

        public StrongContentService(IDocumentTypeFactory documentTypeFactory, UmbracoContext context)
        {
            DocumentTypeFactory = documentTypeFactory;
            _umbracoContext = context;
        }

        public IBasicContentItem GetCurrentNode()
        {
            var currentNodeId = Node.getCurrentNodeId();

            if (currentNodeId < 1)
            {
                return null;
            }

            return DocumentTypeFactory.GetNodeById(currentNodeId);
        }

        public T GetCurrentNode<T>() where T : class, IBasicContentItem
        {
            var currentNodeId = Node.getCurrentNodeId();

            if (currentNodeId < 1)
            {
                return default(T);
            }

            return DocumentTypeFactory.GetNodeById<T>(currentNodeId);
        }

        public IBasicContentItem GetNodeById(int nodeId)
        {
            return DocumentTypeFactory.GetNodeById(nodeId);
        }

        public T GetNodeById<T>(int nodeId) where T : class, IBasicContentItem
        {
            return DocumentTypeFactory.GetNodeById<T>(nodeId);
        }

        #region Children

        public IEnumerable<IBasicContentItem> GetChildNodes(IBasicContentItem parent)
        {
            return GetNodesByIds(parent.ChildIds);
        }

        public IEnumerable<T> GetChildNodes<T>(IBasicContentItem parent) where T : class, IBasicContentItem
        {
            return GetNodesByIds<T>(parent.ChildIds).Where(c => c != null);
        }

        public IEnumerable<IBasicContentItem> GetChildNodes(int parentId)
        {
            var parent = GetNodeById(parentId);
            return GetChildNodes(parent);
        }

        public IEnumerable<T> GetChildNodes<T>(int parentId) where T : class, IBasicContentItem
        {
            var parent = GetNodeById(parentId);
            return GetChildNodes<T>(parent).Where(c => c != null);
        }

        #endregion

        #region Parent

        public IBasicContentItem GetParent(IBasicContentItem child)
        {
            return GetNodeById(child.ParentId);
        }

        public T GetParent<T>(IBasicContentItem child) where T : class, IBasicContentItem
        {
            return GetNodeById<T>(child.ParentId);
        }

        public IBasicContentItem GetParent(int childId)
        {
            var child = GetNodeById(childId);
            return GetNodeById(child.ParentId);
        }

        public T GetParent<T>(int childId) where T : class, IBasicContentItem
        {
            var child = GetNodeById(childId);
            return GetNodeById<T>(child.ParentId);
        }

        #endregion

        public IEnumerable<IBasicContentItem> GetNodesByIds(IEnumerable<int> ids)
        {
            return ids.Where(i => i > 0).Select(GetNodeById);
        }

        public IEnumerable<T> GetNodesByIds<T>(IEnumerable<int> ids) where T : class, IBasicContentItem
        {
            return ids.Where(i => i > 0).Select(i => GetNodeById<T>(i));
        }

        public IEnumerable<IBasicContentItem> GetRootNodes()
        {
            var helper = new UmbracoHelper(_umbracoContext);

            var rootIds = helper.TypedContentAtRoot().Select(n => n.Id);

            return rootIds.Select(GetNodeById);
        }


        public IEnumerable<IBasicContentItem> GetDescendantNodes(IBasicContentItem parent)
        {
            return GetDescendants(parent);
        }

        public IEnumerable<T> GetDescendantNodes<T>(IBasicContentItem parent) where T : class, IBasicContentItem
        {
            return GetDescendants<T>(parent);
        }

        public IEnumerable<IBasicContentItem> GetDescendantNodes(int parentId)
        {
            var content = DocumentTypeFactory.GetNodeById(parentId);

            return GetDescendants(content);
        }

        public IEnumerable<T> GetDescendantNodes<T>(int parentId) where T : class, IBasicContentItem
        {
            var content = DocumentTypeFactory.GetNodeById(parentId);

            return GetDescendants<T>(content);
        }

        private IEnumerable<IBasicContentItem> GetDescendants(IBasicContentItem parent)
        {
            var descendants = new List<IBasicContentItem>();

            var children = GetNodesByIds(parent.ChildIds);

            descendants.AddRange(children);

            descendants.AddRange(children.SelectMany(GetDescendants));

            return descendants;
        }

        private IEnumerable<T> GetDescendants<T>(IBasicContentItem parent) where T : class, IBasicContentItem
        {
            var descendants = new List<T>();

            var children = GetNodesByIds(parent.ChildIds).Where(c => c != null);

            descendants.AddRange(children.Where(c => c is T).Cast<T>());

            descendants.AddRange(children.SelectMany(GetDescendants<T>));

            return descendants;
        }
    }
}