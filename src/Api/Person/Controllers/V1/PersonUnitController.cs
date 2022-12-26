using System;
using System.Threading.Tasks;
using eQuantic.Core.Linq.Filter;
using eQuantic.Core.Linq.Sorter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoCond.Api.Base.Controllers;
using NoCond.Application.Base.Models;
using NoCond.Application.Person.Models;
using NoCond.Application.Person.Services.Interfaces;
using NSwag.Annotations;

namespace NoCond.Api.Person.Controllers.V1
{
    /// <summary>
    /// Person controller.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/people/{personId}/units")]
    [OpenApiTag("Person", Description = "Create, read, update and delete people")]
    public class PersonUnitController: CrudControllerBase<PersonUnitRequest, Application.Unit.Models.Unit, Guid, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonUnitController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public PersonUnitController(IPersonUnitService service) : base(service)
        {
        }

        /// <summary>
        /// Reference Key
        /// </summary>
        protected override string ReferenceKey => ReferenceName;
        private const string ReferenceName = "personId";

        /// <summary>
        /// Gets a unit by person
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
        /// Creates a owner.
        /// </summary>
        /// <param name="referenceId"></param>
        /// <param name="request">The request.</param>
        [HttpPost("")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(int), StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<IActionResult> Post([FromRoute(Name = ReferenceName)] Guid referenceId, [FromBody] PersonUnitRequest request)
        {
            return base.Post(referenceId, request);
        }

        /// <summary>
        /// Updates a owner by identifier.
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
        public override Task<IActionResult> Put([FromRoute(Name = ReferenceName)] Guid referenceId, [FromRoute] Guid id, [FromBody] PersonUnitRequest request)
        {
            return base.Put(referenceId, id, request);
        }

        /// <summary>
        /// Deletes a owner by identifier.
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