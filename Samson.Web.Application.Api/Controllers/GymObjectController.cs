using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using Samson.Web.Application.Api.Requests.GymObject;
using Samson.Web.Application.Api.ViewModels.GymObject;
using Samson.Web.Application.Commands.GymObject;
using Samson.Web.Application.Infrastructure;
using Samson.Web.Application.Models.Dtos.GymObject;
using Samson.Web.Application.Queries.GymObject;

namespace Samson.Web.Application.Api.Controllers
{
    /// <summary>
    /// Gym object API Controller. Provide CRUD operations on GymObject model.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class GymObjectController : ControllerBase
    {
        private readonly ILogger<GymObjectController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        /// Default controller.
        /// </summary>
        /// <param name="logger">Application logger</param>
        /// <param name="mapper">Mapper to map between objects</param>
        /// <param name="mediator">CQRS Mediator</param>
        public GymObjectController(ILogger<GymObjectController> logger, IMapper mapper, IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Get GymObject by id.
        /// </summary>
        /// <param name="id">Id of gym objects</param>
        /// <returns>GymObject</returns>
        [HttpGet("getById/{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            if (id.IsNullOrEmpty())
            {
                return BadRequest();
            }

            var query = _mapper.Map<string, GymObjectQuery>(id);
            var queryResult = await _mediator.Send(query);
            var result = _mapper.Map<GymObjectDto, GymObjectViewModel>(queryResult);
            return Ok(result);
        }

        /// <summary>
        /// Get GymRoom by id.
        /// </summary>
        /// <param name="id">Id of GymRoom</param>
        /// <returns>GymRoom</returns>
        [HttpGet("getRoomById/{id}")]
        public async Task<ActionResult> GetRoomById(string id)
        {
            if (id.IsNullOrEmpty())
            {
                return BadRequest();
            }

            var query = _mapper.Map<string, GetGymRoomByIdQuery>(id);
            var queryResult = await _mediator.Send(query);
            var result = _mapper.Map<GymRoomDetailsDto, GymRoomDetailsViewModel>(queryResult);

            return Ok(result);
        }

        /// <summary>
        /// Get all GymObject view models.
        /// </summary>
        /// <returns>List of all gym objects</returns>
        [HttpGet("getAll")]
        public async Task<ActionResult> GetAll()
        {
            var query = new AllGymObjectQuery();
            var queryResult = await _mediator.Send(query);
            var result = _mapper.Map<IEnumerable<GymObjectDto>, IEnumerable<GymObjectViewModel>>(queryResult);
            return Ok(result);
        }

        /// <summary>
        /// Get all GymRoomDetail view models.
        /// </summary>
        /// <returns>List of all GymRoomDetail view models</returns>
        [HttpGet("getAllRooms")]
        public async Task<ActionResult> GetAllRooms()
        {
            var query = new GetAllGymRoomQuery();
            var queryResult = await _mediator.Send(query);
            var result = _mapper.Map<IEnumerable<GymRoomDetailsDto>, IEnumerable<GymRoomDetailsViewModel>>(queryResult);
            return Ok(result);
        }

        /// <summary>
        /// CreatePersonalTrainer new GymObject.
        /// </summary>
        /// <param name="request">Data to create new GymObject</param>
        [HttpPost("create")]
        public async Task<ActionResult> Create(CreateGymObjectRequest request)
        {
            if (request == null)
                return BadRequest();

            var command = _mapper.Map<CreateGymObjectRequest, CreateGymObjectCommand>(request);
            var result = await _mediator.Send(command);
            return Ok(result.ToJson());
        }

        /// <summary>
        /// Update GymObject.
        /// </summary>
        /// <param name="request">Data to update GymObject</param>
        [HttpPost("update")]
        public async Task<ActionResult> Update(UpdateGymObjectRequest request)
        {
            if (request == null)
                return BadRequest();

            var command = _mapper.Map<UpdateGymObjectRequest, UpdateGymObjectCommand>(request);
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Delete GymObject.
        /// </summary>
        /// <param name="request">Data to find and delete GymObject</param>
        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(DeleteGymObjectRequest request)
        {
            if (request == null)
                return BadRequest();

            var command = _mapper.Map<DeleteGymObjectRequest, DeleteGymObjectCommand>(request);
            await _mediator.Send(command);

            return Ok();
        }

        /// <summary>
        /// Add room to GymObject.
        /// </summary>
        /// <param name="request">Data to add GymRoom to GymObject</param>
        [HttpPost("addRoom")]
        public async Task<ActionResult> AddRoom(AddGymRoomRequest request)
        {
            if (request == null)
                return BadRequest();

            var command = _mapper.Map<AddGymRoomRequest, AddGymRoomCommand>(request);
            var result = await _mediator.Send(command);

            return Ok(result.ToJson());
        }

        /// <summary>
        /// Remove room from GymObject.
        /// </summary>
        /// <param name="request">Data to find GymRoom and remove from GymObject</param>
        [HttpDelete("removeRoom")]
        public async Task<ActionResult> RemoveRoom(RemoveGymRoomRequest request)
        {
            if (request == null)
                return BadRequest();

            var command = _mapper.Map<RemoveGymRoomRequest, RemoveGymRoomCommand>(request);
            await _mediator.Send(command);

            return Ok();
        }
    }
}
