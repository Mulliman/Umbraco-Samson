namespace Samson.MediaTypes
{
    /// <summary>
    /// A media upload that allows the editor to upload some content.
    /// </summary>
    public interface IDownloadable : IBasicMediaItem
    {
        /// <summary>
        ///     Gets or sets the image path.
        /// </summary>
        /// <value>
        ///     The image path.
        /// </value>
        string FilePath { get; }

        /// <summary>
        ///     Gets or sets the size in kb.
        /// </summary>
        /// <value>
        ///     The size in kb.
        /// </value>
        int? SizeInKb { get; }
    }
}