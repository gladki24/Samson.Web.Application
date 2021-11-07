using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using Samson.Web.Application.Api.Requests.GymPass;
using Samson.Web.Application.Api.ViewModels.GymPassType;
using Samson.Web.Application.Commands.GymPass;
using Samson.Web.Application.Infrastructure;
using Samson.Web.Application.Models.Dtos.GymPass;
using Samson.Web.Application.Queries.GymPass;

namespace Samson.Web.Application.Api.Controllers
{
    /// <summary>
    /// GymPass object API controller. Provide CRUD operations on GymPass model.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class GymPassController : ControllerBase
    {
        private readonly ILogger<GymPassController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="logger">Interface for logging</param>
        /// <param name="mapper">Mapper to map between models</param>
        /// <param name="mediator">CQRS mediator</param>
        public GymPassController(ILogger<GymPassController> logger, IMapper mapper, IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Get GymPassType by id.
        /// </summary>
        /// <param name="id">Id of GymPassType</param>
        /// <returns>GymPassType</returns>
        [HttpGet("getById/{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            if (id.IsNullOrEmpty())
            {
                BadRequest();
            }

            var query = _mapper.Map<string, GetGymPassTypeByIdQuery>(id);
            var queryResult = await _mediator.Send(query);
            var result = _mapper.Map<GymPassTypeDto, GymPassTypeViewModel>(queryResult);
            return Ok(result);
        }

        /// <summary>
        /// Get all GymPassType view models.
        /// </summary>
        /// <returns>List of all GymPassTypes</returns>
        [HttpGet("getAll")]
        public async Task<ActionResult> GetAllGymPasses()
        {
            var query = new GetAllGymPassTypesQuery();
            var queryResult = await _mediator.Send(query);
            var result = _mapper.Map<IEnumerable<GymPassTypeDto>, IEnumerable<GymPassTypeViewModel>>(queryResult);
            return Ok(result);
        }

        /// <summary>
        /// Create new GymPassType
        /// </summary>
        /// <param name="request">Data to create new GymPassType</param>
        [HttpPost("create")]
        public async Task<ActionResult> Create(CreateGymPassTypeRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var command = _mapper.Map<CreateGymPassTypeRequest, CreateGymPassTypeCommand>(request);
            var result = await _mediator.Send(command);
            return Ok(result.ToJson());
        }

        /// <summary>
        /// Update GymPassType.
        /// </summary>
        /// <param name="request">Data to update GymPassType</param>
        [HttpPost("update")]
        public async Task<ActionResult> Update(UpdateGymPassTypeRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var command = _mapper.Map<UpdateGymPassTypeRequest, UpdateGymPassTypeCommand>(request);
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Delete GymPassType.
        /// </summary>
        /// <param name="request">Data fo find and delete GymPassType</param>
        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(DeleteGymPassTypeRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var command = _mapper.Map<DeleteGymPassTypeRequest, DeleteGymPassTypeCommand>(request);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
