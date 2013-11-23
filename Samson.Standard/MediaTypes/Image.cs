using Samson.MediaTypes;

namespace Samson.Standard.MediaTypes
{
    public partial class Image : Downloadable, IImage
    {
        public string AlternateText
        {
            get { return Name; }
        }

        public int? Width
        {
            get { return GetProperty<int>("umbracoWidth"); }
        }

        public int? Height
        {
            get { return GetProperty<int>("umbracoHeight"); }
        }

        public string Type
        {
            get { return GetProperty<string>("umbracoExtension"); }
        }
    }
}
