using System.Collections.Generic;
using System.Linq;
using eQuantic.Core.Collections;

namespace NoCond.Application.Base.Models
{
    /// <summary>
    /// Paged List Result
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedListResult<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedListResult{T}"/> class.
        /// </summary>
        /// <param name="items">The items.</param>
        public PagedListResult(IPagedEnumerable<T> items)
        {
            if (items == null)
            {
                return;
            }

            PageIndex = items.PageIndex;
            PageSize = items.PageSize;
            TotalCount = items.TotalCount;
            Items = items.ToList();
        }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public List<T> Items { get; set; }

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

        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        /// <value>
        /// The total count.
        /// </value>
        public long TotalCount { get; set; }
    }
}