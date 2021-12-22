using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Samson.Web.Application.Api.Requests.Gate;
using Samson.Web.Application.Commands.Gate;

namespace Samson.Web.Application.Api.Controllers
{
    /// <summary>
    /// Controller to supervise clients count in gym object.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class GateController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="mapper">Mapper to map between objects</param>
        /// <param name="mediator">CQRS Mediator</param>
        public GateController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Inform about client entrance to gym. Valid is possible to entry gym due to configuration
        /// </summary>
        /// <param name="request">Information about client</param>
        /// <returns>Validation result</returns>
        [HttpPost("Entry")]
        public async Task<ActionResult> Entry(EntryRequest request)
        {
            if (request == null)
                return BadRequest();

            var command = _mapper.Map<EntryRequest, EntryCommand>(request);
            var result = await _mediator.Send(command);
            return Ok(result.ToString().ToJson());
        }

        /// <summary>
        /// Inform about client exit from gym.
        /// </summary>
        /// <param name="request">Information about client</param>
        [HttpPost("exit")]
        public async Task<ActionResult> Exit(ExitRequest request)
        {
            var command = _mapper.Map<ExitRequest, ExitCommand>(request);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("validEntrance")]
        public async Task<ActionResult> ValidEntrance(EntryRequest request)
        {
            var command = _mapper.Map<EntryRequest, ValidEntranceCommand>(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
