using System;
using Samson.MediaTypes;
using Umbraco.Core.Dynamics;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Samson.Basic.MediaTypes
{
    public class BasicMediaType : IBasicMediaType
    {
        /// <summary>
        ///     The Umbraco helper class.
        /// </summary>
        protected readonly UmbracoHelper Helper = new UmbracoHelper(UmbracoContext.Current);

        /// <summary>
        ///     Initializes a new instance of the <see cref="BasicMediaType" /> class.
        /// </summary>
        /// <param name="id">The id.</param>
        public BasicMediaType(int id)
        {
            var mediaItem = Helper.Media(id);

            Item = mediaItem.GetType() != typeof(DynamicNull) ? mediaItem : null; 

            if (Item != null)
            {
                Id = Item.Id;
                Name = Item.Name;
                CreateDateTime = Item.CreateDate;
            }
        }

        /// <summary>
        ///     Gets the media item as stored in Umbraco.
        /// </summary>
        /// <value>
        ///     The item.
        /// </value>
        protected DynamicPublishedContent Item { get; private set; }

        #region Implementation of IMedia

        /// <summary>
        ///     Gets or sets the id of the media item.
        /// </summary>
        /// <value>
        ///     The id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the name of the media item.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the create date time.
        /// </summary>
        /// <value>
        ///     The create date time.
        /// </value>
        public DateTime CreateDateTime { get; set; }

        #endregion
    }
}