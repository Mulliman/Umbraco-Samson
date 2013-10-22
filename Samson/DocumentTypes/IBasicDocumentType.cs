using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samson.DocumentTypes
{
    public interface IBasicDocumentType
    {
        /// <summary>
        ///     Gets the create date.
        /// </summary>
        /// <value>
        ///     The create date.
        /// </value>
        DateTime CreateDate { get; }

        /// <summary>
        ///     Gets the creator id.
        /// </summary>
        /// <value>
        ///     The creator id.
        /// </value>
        int CreatorId { get; }

        /// <summary>
        ///     Gets the name of the creator.
        /// </summary>
        /// <value>
        ///     The name of the creator.
        /// </value>
        string CreatorName { get; }

        /// <summary>
        ///     Gets the id.
        /// </summary>
        /// <value>
        ///     The id.
        /// </value>
        int Id { get; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        string Name { get; }

        /// <summary>
        ///     Gets the nice URL.
        /// </summary>
        /// <value>
        ///     The nice URL.
        /// </value>
        string NiceUrl { get; }

        /// <summary>
        ///     Gets the node type alias.
        /// </summary>
        /// <value>
        ///     The node type alias.
        /// </value>
        string NodeTypeAlias { get; }

        /// <summary>
        ///     Gets or sets the parent id.
        /// </summary>
        /// <value>
        ///     The parent id.
        /// </value>
        int ParentId { get; }

        /// <summary>
        ///     Gets the path.
        /// </summary>
        /// <value>
        ///     The path.
        /// </value>
        string Path { get; }

        /// <summary>
        ///     Gets the sort order.
        /// </summary>
        /// <value>
        ///     The sort order.
        /// </value>
        int SortOrder { get; }

        /// <summary>
        ///     Gets the template.
        /// </summary>
        /// <value>
        ///     The template.
        /// </value>
        int Template { get; }

        /// <summary>
        ///     Gets the update date.
        /// </summary>
        /// <value>
        ///     The update date.
        /// </value>
        DateTime UpdateDate { get; }

        /// <summary>
        ///     Gets the URL.
        /// </summary>
        /// <value>
        ///     The URL.
        /// </value>
        string Url { get; }

        /// <summary>
        ///     Gets the version.
        /// </summary>
        /// <value>
        ///     The version.
        /// </value>
        Guid Version { get; }

        /// <summary>
        ///     Gets the writer ID.
        /// </summary>
        /// <value>
        ///     The writer ID.
        /// </value>
        int WriterId { get; }

        /// <summary>
        ///     Gets the name of the writer.
        /// </summary>
        /// <value>
        ///     The name of the writer.
        /// </value>
        string WriterName { get; }

        /// <summary>
        /// Gets the child nodes.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IBasicDocumentType> GetChildNodes();

        /// <summary>
        /// Gets the child nodes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> GetChildNodes<T>() where T : IBasicDocumentType;
    }
}
