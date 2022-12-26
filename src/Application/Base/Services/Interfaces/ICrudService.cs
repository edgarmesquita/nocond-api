using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eQuantic.Core.Collections;
using NoCond.Application.Base.Models;

namespace NoCond.Application.Base.Services.Interfaces
{
    /// <summary>
    /// CRUD Service
    /// </summary>
    /// <typeparam name="TRequestDto"></typeparam>
    /// <typeparam name="TDto">The type of the dto</typeparam>
    /// <typeparam name="TKey">The type of the key</typeparam>
    /// <typeparam name="TReferenceKey">The type of the reference key</typeparam>
    /// <seealso cref="IApplicationService" />
    public interface ICrudService<in TRequestDto, TDto, TKey, TReferenceKey> : IApplicationService
    {
        /// <summary>
        /// Creates the asynchronous
        /// </summary>
        /// <param name="userId">The user that performed the request</param>
        /// <param name="requestDto">The request object</param>
        /// <returns></returns>
        Task<TKey> CreateAsync (TReferenceKey referenceId, Guid userId, TRequestDto requestDto);

        /// <summary>
        /// Deletes the asynchronous
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <param name="userId">The user that performed the action</param>
        /// <param name="loadedProperties">Child entities to load</param>
        Task DeleteAsync (TReferenceKey referenceId, TKey id, Guid userId, params string[] loadedProperties);

        /// <summary>
        /// Gets the item asynchronous
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <param name="loadedProperties">Child entities to load</param>
        Task<TDto> GetAsync (TReferenceKey referenceId, TKey id, params string[] loadedProperties);

        /// <summary>
        /// Gets the items asynchronous
        /// </summary>
        Task<IPagedEnumerable<TDto>> GetAsync (TReferenceKey referenceId, ReferencedPagedListRequest<TReferenceKey> request);

        /// <summary>
        /// Gets the items asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TDto>> GetAsync (TReferenceKey referenceId, params string[] loadedProperties);

        /// <summary>
        /// Updates the asynchronous
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <param name="userId">The user that performed the request</param>
        /// <param name="requestDto">The request object</param>
        /// <param name="loadedProperties">Child entities to load</param>
        Task UpdateAsync (TReferenceKey referenceId, TKey id, Guid userId, TRequestDto requestDto, params string[] loadedProperties);
    }
    /// <summary>
    /// CRUD Service
    /// </summary>
    /// <typeparam name="TRequestDto"></typeparam>
    /// <typeparam name="TDto">The type of the dto</typeparam>
    /// <typeparam name="TKey">The type of the key</typeparam>
    /// <seealso cref="IApplicationService" />
    public interface ICrudService<in TRequestDto, TDto, TKey> : IApplicationService
    {
        /// <summary>
        /// Creates the asynchronous
        /// </summary>
        /// <param name="userId">The user that performed the request</param>
        /// <param name="requestDto">The request object</param>
        /// <returns></returns>
        Task<TKey> CreateAsync (Guid userId, TRequestDto requestDto);

        /// <summary>
        /// Deletes the asynchronous
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <param name="userId">The user that performed the action</param>
        /// <param name="loadedProperties">Child entities to load</param>
        Task DeleteAsync (TKey id, Guid userId, params string[] loadedProperties);

        /// <summary>
        /// Gets the item asynchronous
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <param name="loadedProperties">Child entities to load</param>
        Task<TDto> GetAsync (TKey id, params string[] loadedProperties);

        /// <summary>
        /// Gets the items asynchronous
        /// </summary>
        Task<IPagedEnumerable<TDto>> GetAsync (PagedListRequest dto);

        /// <summary>
        /// Gets the items asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TDto>> GetAsync (params string[] loadedProperties);

        /// <summary>
        /// Updates the asynchronous
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <param name="userId">The user that performed the request</param>
        /// <param name="requestDto">The request object</param>
        /// <param name="loadedProperties">Child entities to load</param>
        Task UpdateAsync (TKey id, Guid userId, TRequestDto requestDto, params string[] loadedProperties);
    }
}