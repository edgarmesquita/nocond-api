using System;
using System.Linq.Expressions;
using eQuantic.Core.Linq.Specification;
using NoCond.Application.Base.Models;

namespace NoCond.Application.Base.Specifications
{
    /// <summary>
    /// Class ActiveHistorySpecification.
    /// Implements the <see cref="Specification{T}" />
    /// </summary>
    /// <typeparam name="THistoryMetadata">The type of the t history metadata.</typeparam>
    /// <seealso cref="Specification{T}" />
    public class ActiveItemHistorySpecification<THistoryMetadata> : Specification<THistoryMetadata>
        where THistoryMetadata : HistoryMetadata
    {
        /// <summary>
        /// Satisfied by.
        /// </summary>
        /// <returns>Expression&lt;Func&lt;THistoryMetadata, System.Boolean&gt;&gt;.</returns>
        public override Expression<Func<THistoryMetadata, bool>> SatisfiedBy()
        {
            return o => o.EndedOn == null;
        }
    }
}