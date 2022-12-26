using System;
using System.Threading.Tasks;
using eQuantic.Core.Linq.Filter;
using eQuantic.Core.Linq.Sorter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoCond.Api.Base.Controllers;
using NoCond.Application.Base.Models;
using NoCond.Application.Unit.Models;
using NoCond.Application.Unit.Services.Interfaces;
using NSwag.Annotations;

namespace NoCond.Api.Unit.Controllers.V1
{
    /// <summary>
    /// Unit controller.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/unit-groups/{unitGroupId}/units")]
    [OpenApiTag("Unit", Description = "Create, read, update and delete unit, groups and types")]
    public class UnitController : CrudControllerBase<UnitRequest, Application.Unit.Models.Unit, Guid, Guid>
    {
        private readonly IUnitService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public UnitController(IUnitService service) : base(service)
        {
            this.service = service;
        }

        /// <summary>
        /// Reference Key
        /// </summary>
        protected override string ReferenceKey => ReferenceName;
        private const string ReferenceName = "unitGroupId";

        /// <summary>
        /// Gets a unit
        /// </summary>
        /// <param name="referenceId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Application.Unit.Models.Unit), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<IActionResult> Get([FromRoute(Name = ReferenceName)] Guid referenceId, [FromRoute] Guid id)
        {
            return base.Get(referenceId, id);
        }

        /// <summary>
        /// Gets units by criteria.
        /// </summary>
        /// <param name="referenceId"></param>
        /// <param name="filterBy">The filter by.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="pageIndex">The page index.</param>
        /// <param name="pageSize">The page size.</param>
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedListResult<Application.Unit.Models.Unit>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<IActionResult> GetAll([FromRoute(Name = ReferenceName)] Guid referenceId, [FromQuery] IFiltering[] filterBy, [FromQuery] ISorting[] orderBy, [FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            return base.GetAll(referenceId, filterBy, orderBy, pageIndex, pageSize);
        }

        /// <summary>
        /// Creates a unit.
        /// </summary>
        /// <param name="referenceId"></param>
        /// <param name="request">The request.</param>
        [HttpPost("")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(int), StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<IActionResult> Post([FromRoute(Name = ReferenceName)] Guid referenceId, [FromBody] UnitRequest request)
        {
            return base.Post(referenceId, request);
        }
        
        /// <summary>
        /// Creates many units by range.
        /// </summary>
        /// <param name="referenceId"></param>
        /// <param name="request">The request.</param>
        [HttpPost("range")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(int), StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromRoute(Name = ReferenceName)] Guid referenceId, [FromBody] UnitRangeRequest[] request)
        {
            var version = HttpContext.GetRequestedApiVersion ();
            await service.CreateRangeAsync (referenceId, Guid.Empty, request);
            return CreatedAtAction (nameof (GetAll), new { unitGroupId = referenceId, version = $"{version}" }, (object)null);
        }

        /// <summary>
        /// Updates a unit by identifier.
        /// </summary>
        /// <param name="referenceId"></param>
        /// <param name="id">The id.</param>
        /// <param name="request">The request.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(int), StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<IActionResult> Put([FromRoute(Name = ReferenceName)] Guid referenceId, [FromRoute] Guid id, [FromBody] UnitRequest request)
        {
            return base.Put(referenceId, id, request);
        }

        /// <summary>
        /// Deletes a unit by identifier.
        /// </summary>
        /// <param name="referenceId"></param>
        /// <param name="id">The id.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<IActionResult> Delete([FromRoute(Name = ReferenceName)] Guid referenceId, [FromRoute] Guid id)
        {
            return base.Delete(referenceId, id);
        }
    }
}