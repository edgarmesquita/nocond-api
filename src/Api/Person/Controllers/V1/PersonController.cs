using System;
using System.Threading.Tasks;
using eQuantic.Core.Linq.Filter;
using eQuantic.Core.Linq.Sorter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoCond.Api.Base.Controllers;
using NoCond.Application.Base.Models;
using NoCond.Application.Base.Services.Interfaces;
using NoCond.Application.Meeting.Models;
using NoCond.Application.Meeting.Services.Interfaces;
using NoCond.Application.Person.Models;
using NoCond.Application.Person.Services.Interfaces;
using NoCond.Application.Unit.Models;
using NSwag.Annotations;

namespace NoCond.Api.Person.Controllers.V1
{
    /// <summary>
    /// Person controller.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/people")]
    [OpenApiTag("Person", Description = "Create, read, update and delete people")]
    public class PersonController: CrudControllerBase<PersonRequest, Application.Person.Models.Person, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public PersonController(IPersonService service) : base(service)
        {
        }
        
        /// <summary>
        /// Gets a person.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Application.Person.Models.Person), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<IActionResult> Get([FromRoute] Guid id)
        {
            return base.Get(id);
        }

        /// <summary>
        /// Gets people by criteria.
        /// </summary>
        /// <param name="filterBy">The filter by.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="pageIndex">The page index.</param>
        /// <param name="pageSize">The page size.</param>
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedListResult<Application.Person.Models.Person>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<IActionResult> GetAll([FromQuery] IFiltering[] filterBy, [FromQuery] ISorting[] orderBy, [FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            return base.GetAll(filterBy, orderBy, pageIndex, pageSize);
        }

        /// <summary>
        /// Creates a person.
        /// </summary>
        /// <param name="dto">The dto.</param>
        [HttpPost("")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(int), StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<IActionResult> Post([FromBody] PersonRequest dto)
        {
            return base.Post(dto);
        }

        /// <summary>
        /// Updates a person by identifier.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="dto">The dto.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(int), StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<IActionResult> Put([FromRoute] Guid id, [FromBody] PersonRequest dto)
        {
            return base.Put(id, dto);
        }

        /// <summary>
        /// Deletes a person by identifier.
        /// </summary>
        /// <param name="id">The id.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<IActionResult> Delete(Guid id)
        {
            return base.Delete(id);
        }
    }
}