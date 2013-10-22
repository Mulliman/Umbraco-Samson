using System;
using Samson.Basic.MediaTypes;
using Samson.Services;
using Umbraco.Web;

namespace Samson.Basic.Services
{
    public class StrongMediaService : IStrongMediaService
    {
        public StrongMediaService(ITypesRepository repo)
        {

        }

        public ITypesRepository TypeRepository { get; set; }

        /// <summary>
        ///     The Umbraco helper class.
        /// </summary>
        protected readonly UmbracoHelper Helper = new UmbracoHelper(UmbracoContext.Current);

        public Samson.MediaTypes.IBasicMediaType GetMediaItem(int id)
        {
            var current = Helper.Media(id);
            var currentAlias = current.NodeTypeAlias;

            var type = TypeRepository.GetModelTypeFromAlias(currentAlias);

            if (type != typeof(BasicMediaType))
            {
                return (BasicMediaType)Activator.CreateInstance(type, current.Id);
            }

            return new BasicMediaType(current.Id);
        }

        public T GetMediaItem<T>(int id) where T : Samson.MediaTypes.IBasicMediaType
        {
            if (typeof(T).IsInterface)
            {
                var node = GetMediaItem(id);
                return node is T ? (T)node : default(T);
            }

            var instance = (T)Activator.CreateInstance(typeof(T), id);

            return instance;
        }
    }
}
