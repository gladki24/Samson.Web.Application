using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Samson.Web.Application.Api.Requests.Event;
using Samson.Web.Application.Infrastructure;
using System;
using System.Threading.Tasks;

namespace Samson.Web.Application.Api.Controllers
{
    /// <summary>
    /// Event object API Controller. Provide CRUD operations on Event model
    /// </summary>
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="mapper">Mapper to map between objects</param>
        /// <param name="mediator">CQRS Mediator</param>
        public EventController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Get Event by id
        /// </summary>
        /// <param name="id">id of event</param>
        /// <returns>Event</returns>
        [HttpGet("getById/{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            if (id.IsNullOrEmpty())
            {
                BadRequest();
            }
        }

        /// <summary>
        /// Get all events
        /// </summary>
        /// <returns>List of all events</returns>
        [HttpGet("getAll")]
        public async Task<ActionResult> GetAll()
        {

        }

        public async Task<ActionResult> Create(CreateEventRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }
        }

        public async Task<ActionResult> Update(UpdateEventRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }
        }

        public async Task<ActionResult> Delete(DeleteEventRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }
        }
    }
}
