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
    /// Gym object API Controller. Provide CRUD operations on GymObject model
    /// </summary>
    [ApiController]
    public class GymObjectController : ControllerBase
    {
        private readonly ILogger<GymObjectController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GymObjectController(ILogger<GymObjectController> logger, IMapper mapper, IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Get GymObject by id
        /// </summary>
        /// <returns>GymObject</returns>
        [HttpGet("getById/{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            if (id.IsNullOrEmpty())
            {
                BadRequest();
            }

            var query = _mapper.Map<string, GymObjectQuery>(id);
            var queryResult = await _mediator.Send(query);
            var result = _mapper.Map<GymObjectDto, GymObjectViewModel>(queryResult);
            return Ok(result);
        }

        /// <summary>
        /// Get all gym objects
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
        /// Create new gym object
        /// </summary>
        /// <param name="request">Data to create new gym object</param>
        [HttpPost("create")]
        public async Task<ActionResult> Create(CreateGymObjectRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var command = _mapper.Map<CreateGymObjectRequest, CreateGymObjectCommand>(request);
            var result = await _mediator.Send(command);
            return Ok(result.ToJson());
        }

        /// <summary>
        /// Update gym object
        /// </summary>
        /// <param name="request">Data to update gym object</param>
        [HttpPut("update")]
        public async Task<ActionResult> Update(UpdateGymObjectRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var command = _mapper.Map<UpdateGymObjectRequest, UpdateGymObjectCommand>(request);
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Delete gym object
        /// </summary>
        /// <param name="request">Data to find and delete gym object</param>
        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(DeleteGymObjectRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var command = _mapper.Map<DeleteGymObjectRequest, DeleteGymObjectCommand>(request);
            await _mediator.Send(command);

            return Ok();
        }
    }
}
