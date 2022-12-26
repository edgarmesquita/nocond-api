using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eQuantic.Core.Linq.Filter;
using eQuantic.Core.Linq.Sorter;
using Microsoft.AspNetCore.Mvc;
using NoCond.Application.Base.Models;
using NoCond.Application.Base.Services.Interfaces;

namespace NoCond.Api.Base.Controllers
{
    /// <summary>
    /// Referenced CRUD Controller Base
    /// </summary>
    /// <typeparam name="TRequestDto"></typeparam>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TReferenceKey"></typeparam>
    public abstract class CrudControllerBase<TRequestDto, TDto, TKey, TReferenceKey> : ControllerBase
        where TRequestDto : IReferencedRequestBase<TReferenceKey>
        where TDto : class, new ()
    {
        /// <summary>
        /// CRUD Service
        /// </summary>
        protected ICrudService<TRequestDto, TDto, TKey, TReferenceKey> Service { get; }
        
        /// <summary>
        /// Gets the reference key.
        /// </summary>
        /// <value>The reference key.</value>
        protected abstract string ReferenceKey { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CrudControllerBase{TRequestDto, TDto, TKey, TReferenceKey}"/> class.
        /// </summary>
        /// <param name="service"></param>
        /// <seealso cref="T:Microsoft.AspNetCore.Mvc.ControllerBase" />
        protected CrudControllerBase (ICrudService<TRequestDto, TDto, TKey, TReferenceKey> service)
        {
            Service = service;
        }

        /// <summary>
        /// Deletes the specified identifier
        /// </summary>
        /// <param name="referenceId"></param>
        /// <param name="id">The identifier</param>
        /// <returns></returns>
        public virtual async Task<IActionResult> Delete (TReferenceKey referenceId, TKey id)
        {
            await Service.DeleteAsync (referenceId, id, Guid.Empty);
            return NoContent ();
        }

        /// <summary>
        /// Gets the specified identifier
        /// </summary>
        /// <param name="referenceId"></param>
        /// <param name="id">The identifier</param>
        /// <returns></returns>
        public virtual async Task<IActionResult> Get (TReferenceKey referenceId, TKey id)
        {
            var item = await Service.GetAsync (referenceId, id);
            return Ok (item);
        }

        /// <summary>
        /// Gets the specified page index
        /// </summary>
        /// <param name="referenceId"></param>
        /// <param name="filterBy"></param>
        /// <param name="orderBy">Sort collection</param>
        /// <param name="pageIndex">Index of the page</param>
        /// <param name="pageSize">Size of the page</param>
        /// <returns></returns>
        public virtual async Task<IActionResult> GetAll (TReferenceKey referenceId, IFiltering[] filterBy, ISorting[] orderBy, int pageIndex = 1,
            int pageSize = 10)
        {
            var request = new ReferencedPagedListRequest<TReferenceKey>
            {
            FilterBy = filterBy,
            OrderBy = orderBy,
            PageIndex = pageIndex,
            PageSize = pageSize
            };

            var items = await Service.GetAsync (referenceId, request);
            return Ok (new PagedListResult<TDto> (items));
        }

        /// <summary>
        /// Posts the specified item
        /// </summary>
        /// <param name="referenceId"></param>
        /// <param name="request">The request object</param>
        /// <returns></returns>
        public virtual async Task<IActionResult> Post (TReferenceKey referenceId, TRequestDto request)
        {
            var version = HttpContext.GetRequestedApiVersion ();
            var id = await Service.CreateAsync (referenceId, Guid.Empty, request);
            return CreatedAtAction (nameof (Get), GetRouteValues (id, request, version), id);
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="referenceId"></param>
        /// <param name="id">The identifier.</param>
        /// <param name="request">The item.</param>
        /// <returns></returns>
        public virtual async Task<IActionResult> Put (TReferenceKey referenceId, TKey id, TRequestDto request)
        {
            await Service.UpdateAsync (referenceId, id, Guid.Empty, request);
            return NoContent ();
        }

        /// <summary>
        /// Gets the route values.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="request">The request dto.</param>
        /// <param name="version">The version.</param>
        /// <returns></returns>
        protected virtual object GetRouteValues (TKey id, TRequestDto request, ApiVersion version)
        {
            return new Dictionary<string, object> { { ReferenceKey, request.GetReferenceId () }, { "id", id }, { "version", $"{version}" } };
        }
    }

    /// <summary>
    /// CRUD Controller Base
    /// </summary>
    /// <typeparam name="TRequestDto"></typeparam>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public abstract class CrudControllerBase<TRequestDto, TDto, TKey> : ControllerBase
    where TRequestDto : class, new ()
    where TDto : class, new ()
    {
        /// <summary>
        /// CRUD Service
        /// </summary>
        protected ICrudService<TRequestDto, TDto, TKey> Service { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CrudControllerBase{TRequestDto, TDto, TKey}"/> class.
        /// </summary>
        /// <param name="service"></param>
        /// <seealso cref="T:Microsoft.AspNetCore.Mvc.ControllerBase" />
        protected CrudControllerBase (ICrudService<TRequestDto, TDto, TKey> service)
        {
            Service = service;
        }

        /// <summary>
        /// Deletes the specified identifier
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <returns></returns>
        public virtual async Task<IActionResult> Delete (TKey id)
        {
            await Service.DeleteAsync (id, Guid.Empty);
            return NoContent ();
        }

        /// <summary>
        /// Gets the specified identifier
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <returns></returns>
        public virtual async Task<IActionResult> Get (TKey id)
        {
            var item = await Service.GetAsync (id);
            return Ok (item);
        }

        /// <summary>
        /// Gets the specified page index
        /// </summary>
        /// <param name="filterBy"></param>
        /// <param name="orderBy">Sort collection</param>
        /// <param name="pageIndex">Index of the page</param>
        /// <param name="pageSize">Size of the page</param>
        /// <returns></returns>
        public virtual async Task<IActionResult> GetAll (IFiltering[] filterBy, ISorting[] orderBy, int pageIndex = 1,
            int pageSize = 10)
        {
            var dto = new PagedListRequest
            {
            FilterBy = filterBy,
            OrderBy = orderBy,
            PageIndex = pageIndex,
            PageSize = pageSize
            };

            var items = await Service.GetAsync (dto);
            return Ok (new PagedListResult<TDto> (items));
        }

        /// <summary>
        /// Posts the specified item
        /// </summary>
        /// <param name="request">The request object</param>
        /// <returns></returns>
        public virtual async Task<IActionResult> Post (TRequestDto request)
        {
            var version = HttpContext.GetRequestedApiVersion ();
            var id = await Service.CreateAsync (Guid.Empty, request);
            return CreatedAtAction (nameof (Get), GetRouteValues (id, request, version), id);
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="request">The item.</param>
        /// <returns></returns>
        public virtual async Task<IActionResult> Put (TKey id, TRequestDto request)
        {
            await Service.UpdateAsync (id, Guid.Empty, request);
            return NoContent ();
        }

        /// <summary>
        /// Gets the route values.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="request">The request dto.</param>
        /// <param name="version">The version.</param>
        /// <returns></returns>
        protected virtual object GetRouteValues (TKey id, TRequestDto request, ApiVersion version)
        {
            return new { id, version = $"{version}" };
        }
    }
}