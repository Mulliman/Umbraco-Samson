using System;
using System.Collections.Generic;

namespace Samson.DocumentTypes
{
    public interface IBasicContentItem
    {
        /// <summary>
        /// Gets or sets the child ids.
        /// </summary>
        /// <value>
        /// The child ids.
        /// </value>
        IEnumerable<int> ChildIds { get; set; }

        /// <summary>
        ///     Gets the create date.
        /// </summary>
        /// <value>
        ///     The create date.
        /// </value>
        DateTime CreateDate { get; set; }

        /// <summary>
        ///     Gets the creator id.
        /// </summary>
        /// <value>
        ///     The creator id.
        /// </value>
        int CreatorId { get; set; }

        /// <summary>
        ///     Gets the name of the creator.
        /// </summary>
        /// <value>
        ///     The name of the creator.
        /// </value>
        string CreatorName { get; set; }

        /// <summary>
        ///     Gets the id.
        /// </summary>
        /// <value>
        ///     The id.
        /// </value>
        int Id { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        string Name { get; set; }

        /// <summary>
        ///     Gets the nice URL.
        /// </summary>
        /// <value>
        ///     The nice URL.
        /// </value>
        string NiceUrl { get; set; }

        /// <summary>
        ///     Gets the node type alias.
        /// </summary>
        /// <value>
        ///     The node type alias.
        /// </value>
        string NodeTypeAlias { get; set; }

        /// <summary>
        ///     Gets or sets the parent id.
        /// </summary>
        /// <value>
        ///     The parent id.
        /// </value>
        int ParentId { get; set; }

        /// <summary>
        ///     Gets the path.
        /// </summary>
        /// <value>
        ///     The path.
        /// </value>
        string Path { get; set; }

        /// <summary>
        ///     Gets the sort order.
        /// </summary>
        /// <value>
        ///     The sort order.
        /// </value>
        int SortOrder { get; set; }

        /// <summary>
        ///     Gets the template.
        /// </summary>
        /// <value>
        ///     The template.
        /// </value>
        int Template { get; set; }

        /// <summary>
        ///     Gets the update date.
        /// </summary>
        /// <value>
        ///     The update date.
        /// </value>
        DateTime UpdateDate { get; set; }

        /// <summary>
        ///     Gets the URL.
        /// </summary>
        /// <value>
        ///     The URL.
        /// </value>
        string Url { get; set; }

        /// <summary>
        ///     Gets the version.
        /// </summary>
        /// <value>
        ///     The version.
        /// </value>
        Guid Version { get; set; }

        /// <summary>
        ///     Gets the writer ID.
        /// </summary>
        /// <value>
        ///     The writer ID.
        /// </value>
        int WriterId { get; set; }

        /// <summary>
        ///     Gets the name of the writer.
        /// </summary>
        /// <value>
        ///     The name of the writer.
        /// </value>
        string WriterName { get; set;}
    }
}
