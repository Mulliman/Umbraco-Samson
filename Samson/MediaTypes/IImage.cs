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
        string AlternateText { get; set; }

        /// <summary>
        ///     Gets or sets the width.
        /// </summary>
        /// <value>
        ///     The width.
        /// </value>
        int? Width { get; set; }

        /// <summary>
        ///     Gets or sets the height.
        /// </summary>
        /// <value>
        ///     The height.
        /// </value>
        int? Height { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        string Type { get; set; }
    }
}