using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoCond.Api.Base.Controllers;
using NoCond.Application.Base.Services.Interfaces;
using NoCond.Application.Settings.Models;
using NoCond.Application.Settings.Services.Interfaces;
using NoCond.Application.Unit.Models;
using NSwag.Annotations;

namespace NoCond.Api.Settings.V1.Controllers
{
    /// <summary>
    /// Meeting Settings
    /// </summary>
    [ApiController]
    [ApiVersion ("1.0")]
    [Route ("v{version:apiVersion}/settings/meetings")]
    [OpenApiTag ("Settings", Description = "Create, read and update settings")]
    public class MeetingSettingsController : OnlyOneControllerBase<MeetingSettingsRequest, MeetingSettings>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public MeetingSettingsController(IOnlyOneService<MeetingSettingsRequest, MeetingSettings> service) : base(service)
        {
        }

        /// <summary>
        /// Gets the current meeting settings
        /// </summary>
        /// <returns></returns>
        [HttpGet ("")]
        [ProducesResponseType (typeof (MeetingSettings), StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public override Task<IActionResult> Get()
        {
            return base.Get();
        }

        /// <summary>
        /// Updates the meeting settings
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost ("")]
        [ProducesResponseType (StatusCodes.Status201Created)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public override Task<IActionResult> Post([FromBody]MeetingSettingsRequest request)
        {
            return base.Post(request);
        }
    }
}