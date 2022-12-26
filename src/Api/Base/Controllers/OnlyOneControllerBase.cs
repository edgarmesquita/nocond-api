using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoCond.Application.Base.Services.Interfaces;

namespace NoCond.Api.Base.Controllers
{
    /// <summary>
    /// Class ReferencedOnlyOneControllerBase.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <typeparam name="TRequestDto">The type of the t request dto.</typeparam>
    /// <typeparam name="TDto">The type of the t dto.</typeparam>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    public abstract class OnlyOneControllerBase<TRequestDto, TDto> : ControllerBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="OnlyOneControllerBase{TRequestDto, TDto}"/> class.
        /// </summary>
        /// <param name="service">The referenced only one service.</param>
        protected OnlyOneControllerBase(IOnlyOneService<TRequestDto, TDto> service)
        {
            Service = service;
        }

        /// <summary>
        /// Gets the referenced only one service.
        /// </summary>
        /// <value>The referenced only one service.</value>
        protected IOnlyOneService<TRequestDto, TDto> Service { get; }

        /// <summary>
        /// Creates the item.
        /// </summary>
        /// <param name="request">The dto.</param>
        /// <returns></returns>
        public virtual async Task<IActionResult> Post(TRequestDto request)
        {
            var version = HttpContext.GetRequestedApiVersion();
            await Service.CreateAsync(Guid.Empty, request);
            return CreatedAtAction(nameof(Get), GetRouteValues(version), (object)null);
        }

        /// <summary>
        /// Gets the item by identifier.
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IActionResult> Get()
        {
            var item = await Service.GetAsync();
            return Ok(item);
        }

        /// <summary>
        /// Gets the route values.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <returns></returns>
        protected virtual object GetRouteValues(ApiVersion version)
        {
            return new Dictionary<string, object> { { "version", $"{version}" } };
        }
    }
}