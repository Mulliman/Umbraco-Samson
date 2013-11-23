using System;
using Samson.Standard.DocumentTypes;

namespace Samson.Demo.DocumentTypes
{
    [DocumentTypeAlias("blogArticle")]
    public class BlogPage : Page
    {
        public DateTime DisplayDate { get { return GetProperty<DateTime>("displayDate"); } }

        public int ListingImageId { get { return GetProperty<int>("listingImage"); } }
    }
}