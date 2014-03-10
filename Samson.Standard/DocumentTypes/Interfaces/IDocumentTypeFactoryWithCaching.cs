namespace Samson.Standard.DocumentTypes.Interfaces
{
    public interface IDocumentTypeFactoryWithCaching
    {
        void ClearCachedNode(int id);
    }
}