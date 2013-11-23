namespace Samson.Standard.DocumentTypes
{
    public class DocumentTypeAliasAttribute : System.Attribute
    {
        public string Alias
        {
            get
            {
                return _alias;
            }
            set
            {

                _alias = value;
            }
        }

        public DocumentTypeAliasAttribute(string alias)
        {
            _alias = alias;
        }

        private string _alias;
    }
}