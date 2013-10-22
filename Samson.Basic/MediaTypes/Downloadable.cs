using System;
using System.Linq;
using Samson.Basic.MediaTypes;
using Samson.MediaTypes;

namespace Samson.Basic.MediaTypes
{
    public class Downloadable : BasicMediaType, IDownloadable
    {
        private const string UploadPathKey = "umbracoFile";
        private const string SizeKey = "umbracoBytes";
        private const string ExtensionKey = "umbracoExtension";

        /// <summary>
        ///     Initializes a new instance of the <see cref="Downloadable" /> class.
        /// </summary>
        /// <param name="id">The id.</param>
        public Downloadable(int id) : base(id)
        {
            if (Item != null)
            {
                SetUpFilePath();
                SetUpFileSize();
                SetUpFileExtension();
            }
        }

        private void SetUpFilePath()
        {
            var filePathProperty = Item.Properties.FirstOrDefault(p => p.Alias.Equals(UploadPathKey, StringComparison.OrdinalIgnoreCase));

            if (filePathProperty != null)
            {
                FilePath = filePathProperty.Value.ToString();
            }
        }

        private void SetUpFileExtension()
        {
            var fileExtensionProperty = Item.Properties.FirstOrDefault(p => p.Alias.Equals(ExtensionKey, StringComparison.OrdinalIgnoreCase));

            if (fileExtensionProperty != null)
            {
                Type = fileExtensionProperty.Value.ToString();
            }
        }

        private void SetUpFileSize()
        {
            var fileSizeProperty = Item.Properties.FirstOrDefault(p => p.Alias.Equals(SizeKey, StringComparison.OrdinalIgnoreCase));

            if (fileSizeProperty == null)
            {
                SizeInKb = null;
            }
            else
            {
                var sizeInBytes = fileSizeProperty.Value.ToString();

                int sizeInBytesInt;
                if (int.TryParse(sizeInBytes, out sizeInBytesInt) && sizeInBytesInt > 0)
                {
                    SizeInKb = sizeInBytesInt / 1024;
                }
                else
                {
                    SizeInKb = 0;
                }
            }
        }

        #region Implementation of IUpload

        /// <summary>
        ///     Gets or sets the image path.
        /// </summary>
        /// <value>
        ///     The image path.
        /// </value>
        public string FilePath { get; set; }

        /// <summary>
        ///     Gets or sets the size in kb.
        /// </summary>
        /// <value>
        ///     The size in kb.
        /// </value>
        public int? SizeInKb { get; set; }

        /// <summary>
        /// Gets or sets the extension of the file.
        /// </summary>
        /// <value>
        /// The extension.
        /// </value>
        public string Type { get; set; }

        #endregion
    }
}