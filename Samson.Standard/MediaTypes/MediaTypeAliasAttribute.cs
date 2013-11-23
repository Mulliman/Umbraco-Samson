namespace Samson.Standard.MediaTypes
{
    public class MediaTypeAliasAttribute : System.Attribute
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

        public MediaTypeAliasAttribute(string alias)
        {
            _alias = alias;
        }

        private string _alias;
    }
}
