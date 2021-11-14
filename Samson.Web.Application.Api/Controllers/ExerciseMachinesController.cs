using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Samson.Web.Application.Api.Requests.ExerciseMachine;
using Samson.Web.Application.Api.ViewModels.ExerciseMachine;
using Samson.Web.Application.Commands.ExerciseMachine;
using Samson.Web.Application.Infrastructure;
using Samson.Web.Application.Models.Dtos.ExerciseMachine;
using Samson.Web.Application.Queries.ExerciseMachine;

namespace Samson.Web.Application.Api.Controllers
{
    /// <summary>
    /// Exercise machines API controller. Provide CRUD operations on ExerciseMachine model.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ExerciseMachinesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        /// Default controller.
        /// </summary>
        /// <param name="mapper">Mapper to map between objects</param>
        /// <param name="mediator">CQRS Mediator</param>
        public ExerciseMachinesController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Get ExerciseMachine by id.
        /// </summary>
        /// <param name="id">Id of ExerciseMachine</param>
        /// <returns>ExerciseMachine</returns>
        [HttpGet("getById/{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            if (id.IsNullOrEmpty())
            {
                BadRequest();
            }

            var query = _mapper.Map<string, GetExerciseMachineByIdQuery>(id);
            var queryResult = await _mediator.Send(query);
            var result = _mapper.Map<ExerciseMachineDto, ExerciseMachineViewModel>(queryResult);

            return Ok(result);
        }

        /// <summary>
        /// Get all ExerciseMachine view models.
        /// </summary>
        /// <returns>List of all ExerciseMachines</returns>
        [HttpGet("getAll")]
        public async Task<ActionResult> GetAll()
        {
            var query = new GetAllExerciseMachinesQuery();
            var queryResult = await _mediator.Send(query);
            var result = _mapper.Map<IEnumerable<ExerciseMachineDto>, IEnumerable<ExerciseMachineViewModel>>(queryResult);

            return Ok(result);
        }

        /// <summary>
        /// CreatePersonalTrainer new ExerciseMachine.
        /// </summary>
        /// <param name="request">Data to create new ExerciseMachine</param>
        [HttpPost("create")]
        public async Task<ActionResult> Create(CreateExerciseMachineRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var command = _mapper.Map<CreateExerciseMachineRequest, CreateExerciseMachineCommand>(request);
            var result = await _mediator.Send(command);
            return Ok(result.ToJson());
        }

        /// <summary>
        /// Update ExerciseMachine.
        /// </summary>
        /// <param name="request">Data to update ExerciseMachine</param>
        [HttpPost("update")]
        public async Task<ActionResult> Update(UpdateExerciseMachineRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var command = _mapper.Map<UpdateExerciseMachineRequest, UpdateExerciseMachineCommand>(request);
            await _mediator.Send(command);
            return Ok(request.ToJson());
        }

        /// <summary>
        /// Delete ExerciseMachine.
        /// </summary>
        /// <param name="request">Data to find and delete ExerciseMachine</param>
        [HttpPost("delete")]
        public async Task<ActionResult> Delete(DeleteExerciseMachineRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var command = _mapper.Map<DeleteExerciseMachineRequest, DeleteExerciseMachineCommand>(request);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
