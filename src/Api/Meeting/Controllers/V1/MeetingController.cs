using System;
using System.Threading.Tasks;
using eQuantic.Core.Linq.Filter;
using eQuantic.Core.Linq.Sorter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoCond.Api.Base.Controllers;
using NoCond.Application.Base.Models;
using NoCond.Application.Meeting.Models;
using NoCond.Application.Meeting.Services.Interfaces;
using NSwag.Annotations;

namespace NoCond.Api.Meeting.Controllers.V1
{
    /// <summary>
    /// Meeting controller.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/unit-groups/{unitGroupId}/meetings")]
    [OpenApiTag("Meeting", Description = "Create, read, update and delete meetings and types")]
    public class MeetingController : CrudControllerBase<MeetingRequest, Application.Meeting.Models.Meeting, Guid, Guid>
    {
        private readonly IMeetingService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="MeetingController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public MeetingController(IMeetingService service) : base(service)
        {
            this.service = service;
        }

        /// <summary>
        /// Reference Key
        /// </summary>
        protected override string ReferenceKey => ReferenceName;
        private const string ReferenceName = "unitGroupId";

        /// <summary>
        /// Gets a meeting
        /// </summary>
        /// <param name="referenceId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(NoCond.Application.Meeting.Models.Meeting), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<IActionResult> Get([FromRoute(Name = ReferenceName)] Guid referenceId, [FromRoute] Guid id)
        {
            return base.Get(referenceId, id);
        }

        /// <summary>
        /// Gets meetings by criteria.
        /// </summary>
        /// <param name="referenceId">The unit group identifier.</param>
        /// <param name="filterBy">The filter by.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="pageIndex">The page index.</param>
        /// <param name="pageSize">The page size.</param>
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedListResult<NoCond.Application.Meeting.Models.Meeting>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<IActionResult> GetAll([FromRoute(Name = ReferenceName)] Guid referenceId, [FromQuery] IFiltering[] filterBy, [FromQuery] ISorting[] orderBy, [FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            return base.GetAll(referenceId, filterBy, orderBy, pageIndex, pageSize);
        }

        /// <summary>
        /// Creates a meeting.
        /// </summary>
        /// <param name="referenceId">The unit group identifier.</param>
        /// <param name="dto">The dto.</param>
        [HttpPost("")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(int), StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<IActionResult> Post([FromRoute(Name = ReferenceName)] Guid referenceId, [FromBody] MeetingRequest dto)
        {
            return base.Post(referenceId, dto);
        }

        /// <summary>
        /// Updates a meeting by identifier.
        /// </summary>
        /// <param name="referenceId">The unit group identifier.</param>
        /// <param name="id">The id.</param>
        /// <param name="dto">The dto.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(int), StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<IActionResult> Put([FromRoute(Name = ReferenceName)] Guid referenceId, [FromRoute] Guid id, [FromBody] MeetingRequest dto)
        {
            return base.Put(referenceId, id, dto);
        }

        /// <summary>
        /// Deletes a meeting by identifier.
        /// </summary>
        /// <param name="referenceId">The unit group identifier.</param>
        /// <param name="id">The id.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<IActionResult> Delete([FromRoute(Name = ReferenceName)] Guid referenceId, Guid id)
        {
            return base.Delete(referenceId, id);
        }

        /// <summary>
        /// Invite.
        /// </summary>
        /// <param name="referenceId">The unit group identifier.</param>
        /// <param name="id">The id.</param>
        [HttpPost("{id}/invite")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Invite([FromRoute(Name = ReferenceName)] Guid referenceId, Guid id)
        {
            await service.SendInviteAsync(id);
            return Accepted();
        }
    }
}