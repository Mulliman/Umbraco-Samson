namespace Samson.MediaTypes
{
    /// <summary>
    ///     An image media item
    /// </summary>
    public interface IImage : IDownloadable
    {
        /// <summary>
        ///     Gets or sets the alternate text.
        /// </summary>
        /// <value>
        ///     The alternate text.
        /// </value>
        string AlternateText { get; }

        /// <summary>
        ///     Gets or sets the width.
        /// </summary>
        /// <value>
        ///     The width.
        /// </value>
        int? Width { get; }

        /// <summary>
        ///     Gets or sets the height.
        /// </summary>
        /// <value>
        ///     The height.
        /// </value>
        int? Height { get; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        string Type { get; }
    }
}