using Samson.MediaTypes;

namespace Samson.Standard.MediaTypes.Interfaces
{
    public interface IMediaTypeFactory
    {
        /// <summary>
        /// Gets the media item by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IBasicMediaItem GetMediaItemById(int id);

        /// <summary>
        /// Gets the media item by identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        T GetMediaItemById<T>(int id) where T : class, IBasicMediaItem;
    }
}
