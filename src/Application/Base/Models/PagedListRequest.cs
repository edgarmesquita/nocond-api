using eQuantic.Core.Linq.Filter;
using eQuantic.Core.Linq.Sorter;

namespace NoCond.Application.Base.Models
{
    /// <summary>
    /// Paged List Request
    /// </summary>
    public class PagedListRequest
    {
        /// <summary>
        /// Gets or sets the filter by.
        /// </summary>
        /// <value>
        /// The filter by.
        /// </value>
        public IFiltering[] FilterBy { get; set; }

        /// <summary>
        /// Gets or sets the loaded properties.
        /// </summary>
        /// <value>
        /// The loaded properties.
        /// </value>
        public string[] LoadedProperties { get; set; }

        /// <summary>
        /// Gets or sets the order by.
        /// </summary>
        /// <value>
        /// The order by.
        /// </value>
        public ISorting[] OrderBy { get; set; }

        /// <summary>
        /// Gets or sets the index of the page.
        /// </summary>
        /// <value>
        /// The index of the page.
        /// </value>
        public int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int PageSize { get; set; }
    }
}