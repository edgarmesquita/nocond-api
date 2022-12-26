using System;
using System.Threading.Tasks;

namespace NoCond.Application.Base.Services.Interfaces
{
    /// <summary>
    /// Interface IReferencedOnlyOneService
    /// Implements the <see cref="IApplicationService" />
    /// </summary>
    /// <typeparam name="TRequestDto">The type of the request DTO.</typeparam>
    /// <typeparam name="TDto">The type of the DTO.</typeparam>
    /// <seealso cref="IApplicationService" />
    public interface IOnlyOneService<in TRequestDto, TDto> : IApplicationService
    {
        /// <summary>
        /// Creates the asynchronous
        /// </summary>
        /// <param name="userId">The user that performed the request</param>
        /// <param name="requestDto">The request object</param>
        /// <returns></returns>
        Task CreateAsync(Guid userId, TRequestDto requestDto);

        /// <summary>
        /// Gets the item asynchronous
        /// </summary>
        /// <param name="loadedProperties">Child entities to load</param>
        Task<TDto> GetAsync(params string[] loadedProperties);
    }
}