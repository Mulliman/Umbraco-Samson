using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samson.MediaTypes
{
    public interface IBasicMediaType
    {
        /// <summary>
        ///     Gets or sets the id of the media item.
        /// </summary>
        /// <value>
        ///     The id.
        /// </value>
        int Id { get; set; }

        /// <summary>
        ///     Gets or sets the name of the media item.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        string Name { get; set; }

        /// <summary>
        ///     Gets or sets the create date time.
        /// </summary>
        /// <value>
        ///     The create date time.
        /// </value>
        DateTime CreateDateTime { get; set; }
    }
}
