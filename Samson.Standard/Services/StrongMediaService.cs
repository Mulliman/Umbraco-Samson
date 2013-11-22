using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samson.Services;
using Samson.Standard.MediaTypes.Interfaces;
using Umbraco.Core.Models;

namespace Samson.Standard.Services
{
    public class StrongMediaService : IStrongMediaService
    {
        public IMediaTypeFactory MediaTypeFactory { get; set; }

        public StrongMediaService()
        {
            MediaTypeFactory = SamsonContext.Current.MediaTypeFactory;
        }

        public StrongMediaService(IMediaTypeFactory mediaTypeFactory)
        {
            MediaTypeFactory = mediaTypeFactory;
        }

        public Samson.MediaTypes.IBasicMediaItem GetMediaItem(int id)
        {
            return MediaTypeFactory.GetMediaItemById(id);
        }

        public T GetMediaItem<T>(int id) where T : class, Samson.MediaTypes.IBasicMediaItem
        {
            return MediaTypeFactory.GetMediaItemById<T>(id);
        }
    }
}
