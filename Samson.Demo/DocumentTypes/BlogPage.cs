using System;

namespace Samson.Demo.DocumentTypes
{
    public class BlogPage : Page
    {
        public DateTime DisplayDate { get { return GetProperty<DateTime>("displayDate"); } }

        public int ListingImageId { get { return GetProperty<int>("listingImage"); } }
    }
}