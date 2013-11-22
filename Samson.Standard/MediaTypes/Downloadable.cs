using System;
using Samson.MediaTypes;
namespace Samson.Standard.MediaTypes
{
    public class Downloadable : BasicMediaItem, IDownloadable
    {
        public string FilePath
        {
            get { return GetProperty<string>("umbracoFile"); }
        }

        public int? SizeInKb
        {
            get 
            { 
                var bytes = GetProperty<int>("umbracoBytes");

                if(bytes == 0)
                {
                    return 0;
                }

                var kBytes = bytes / 1024;

                return kBytes > 1 ? kBytes : 1;
            }
        }
    }
}
