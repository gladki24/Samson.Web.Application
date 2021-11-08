using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Samson.Web.Application.Api.Requests.Event;
using Samson.Web.Application.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Api.ViewModels.Event;
using Samson.Web.Application.Commands.Event;
using Samson.Web.Application.Models.Dtos.Event;
using Samson.Web.Application.Queries.Event;

namespace Samson.Web.Application.Api.Controllers
{
    /// <summary>
    /// Event object API Controller. Provide CRUD operations on Event model.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="mapper">Mapper to map between objects</param>
        /// <param name="mediator">CQRS Mediator</param>
        public EventController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Get Event by id.
        /// </summary>
        /// <param name="id">Id of event</param>
        /// <returns>Event</returns>
        [HttpGet("getById/{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            if (id.IsNullOrEmpty())
            {
                BadRequest();
            }

            var query = _mapper.Map<string, GetEventByIdQuery>(id);
            var queryResult = await _mediator.Send(query);
            var result = _mapper.Map<EventDto, EventViewModel>(queryResult);
            return Ok(result);
        }

        /// <summary>
        /// Get all Event view models.
        /// </summary>
        /// <returns>List of all Events</returns>
        [HttpGet("getAll")]
        public async Task<ActionResult> GetAll()
        {
            var query = new GetAllEventsQuery();
            var queryResult = await _mediator.Send(query);
            var result = _mapper.Map<IEnumerable<EventDto>, IEnumerable<EventViewModel>>(queryResult);
            return Ok(result);
        }

        /// <summary>
        /// Create new Event.
        /// </summary>
        /// <param name="request">Data to create new Event</param>
        [HttpPost("create")]
        public async Task<ActionResult> Create(CreateEventRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var command = _mapper.Map<CreateEventRequest, CreateEventCommand>(request);
            var result = await _mediator.Send(command);
            return Ok(result.ToJson());
        }

        /// <summary>
        /// Update Event.
        /// </summary>
        /// <param name="request">Data to update Event</param>
        [HttpPost("update")]
        public async Task<ActionResult> Update(UpdateEventRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var command = _mapper.Map<UpdateEventRequest, UpdateEventCommand>(request);
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Delete Event.
        /// </summary>
        /// <param name="request">Data to find and delete Event</param>
        /// <returns>Data to find and delete Event</returns>
        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(DeleteEventRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var command = _mapper.Map<DeleteEventRequest, DeleteEventCommand>(request);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
