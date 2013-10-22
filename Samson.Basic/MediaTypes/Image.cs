using System;
using System.Linq;
using Samson.MediaTypes;

namespace Samson.Basic.MediaTypes
{
    /// <summary>
    /// An image media item.
    /// </summary>
    public class Image : Downloadable, IImage
    {
        private const string WidthKey = "umbracoWidth";
        private const string HeightKey = "umbracoHeight";
        private const string AlternateTextKey = "alternateText";

        public Image(int id) : base(id)
        {
            if (Item != null)
            {
                SetUpAlternateText();
                SetUpWidth();
                SetUpHeight();
            }
            
        }

        private void SetUpAlternateText()
        {
            var alternateTextProperty = Item.Properties.FirstOrDefault(p => p.Alias.Equals(AlternateTextKey, StringComparison.OrdinalIgnoreCase));

            if (alternateTextProperty != null)
            {
                AlternateText = alternateTextProperty.Value.ToString();
            }
        }

        private void SetUpWidth()
        {
            var widthProperty = Item.Properties.FirstOrDefault(p => p.Alias.Equals(WidthKey, StringComparison.OrdinalIgnoreCase));

            if (widthProperty != null)
            {
                int width;
                Width = int.TryParse(widthProperty.Value.ToString(), out width) ? width : default(int?);
            }
        }

        private void SetUpHeight()
        {
            var heightProperty = Item.Properties.FirstOrDefault(p => p.Alias.Equals(HeightKey, StringComparison.OrdinalIgnoreCase));

            if (heightProperty != null)
            {
                int height;
                Height = int.TryParse(heightProperty.Value.ToString(), out height) ? height : default(int?);
            }
        }

        #region Implementation of IImage

        /// <summary>
        ///     Gets or sets the alternate text.
        /// </summary>
        /// <value>
        ///     The alternate text.
        /// </value>
        public string AlternateText { get; set; }

        /// <summary>
        ///     Gets or sets the width.
        /// </summary>
        /// <value>
        ///     The width.
        /// </value>
        public int? Width { get; set; }

        /// <summary>
        ///     Gets or sets the height.
        /// </summary>
        /// <value>
        ///     The height.
        /// </value>
        public int? Height { get; set; }

        #endregion
    }
}