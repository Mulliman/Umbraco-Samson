﻿using Samson.MediaTypes;

namespace Samson.Services
{
    public interface IStrongMediaService
    {
        /// <summary>
        /// Gets the media item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IBasicMediaItem GetMediaItem(int id);

        /// <summary>
        /// Gets the media item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        T GetMediaItem<T>(int id) where T : class, IBasicMediaItem;
    }
}
