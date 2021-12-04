using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Samson.Web.Application.Api.Requests.IndividualTraining;
using Samson.Web.Application.Api.ViewModels.IndividualTraining;
using Samson.Web.Application.Commands.IndividualTraining;
using Samson.Web.Application.Infrastructure;
using Samson.Web.Application.Models.Dtos.IndividualTraining;
using Samson.Web.Application.Queries.IndividualTraining;

namespace Samson.Web.Application.Api.Controllers
{
    /// <summary>
    /// IndividualTraining API controller.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class IndividualTrainingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="mapper">Mapper to map between objects</param>
        /// <param name="mediator">CQRS Mediator</param>
        public IndividualTrainingController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Get IndividualTraining by Id.
        /// </summary>
        /// <param name="id">Id of IndividualTraining</param>
        /// <returns>IndividualTraining</returns>
        [HttpGet("getById/{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            if (id.IsNullOrEmpty())
                return BadRequest();

            var query = _mapper.Map<string, GetIndividualTrainingByIdQuery>(id);
            var queryResult = await _mediator.Send(query);
            var result = _mapper.Map<IndividualTrainingDto, IndividualTrainingViewModel>(queryResult);
            return Ok(result);
        }

        /// <summary>
        /// Get all IndividualTraining
        /// </summary>
        /// <returns>List of all IndividualTraining view models</returns>
        [HttpGet("getAll")]
        public async Task<ActionResult> GetAll()
        {
            var query = new GetAllIndividualTrainingQuery();
            var queryResult = await _mediator.Send(query);
            var result =
                _mapper.Map<IEnumerable<IndividualTrainingDto>, IEnumerable<IndividualTrainingViewModel>>(queryResult);
            return Ok(result);
        }

        /// <summary>
        /// Create new IndividualTraining.
        /// </summary>
        /// <param name="request">Data to create new IndividualTraining</param>
        [HttpPost("create")]
        public async Task<ActionResult> Create(CreateIndividualTrainingRequest request)
        {
            if (request == null)
                return BadRequest();

            var command = _mapper.Map<CreateIndividualTrainingRequest, CreateIndividualTrainingCommand>(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Update IndividualTraining.
        /// </summary>
        /// <param name="request">Data to update new IndividualTraining</param>
        [HttpPost("update")]
        public async Task<ActionResult> Update(UpdateIndividualTrainingRequest request)
        {
            if (request == null)
                return BadRequest();

            var command = _mapper.Map<UpdateIndividualTrainingRequest, UpdateIndividualTrainingCommand>(request);
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Cancel IndividualTraining.
        /// </summary>
        /// <param name="request">Data to cancel IndividualTraining</param>
        [HttpPost("cancel")]
        public async Task<ActionResult> Cancel(CancelIndividualTrainingRequest request)
        {
            if (request == null)
                return BadRequest();

            var command = _mapper.Map<CancelIndividualTrainingRequest, CancelIndividualTrainingCommand>(request);
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Enroll in IndividualTraining.
        /// </summary>
        /// <param name="request">Data to enroll in IndividualTraining</param>
        [HttpPost("enroll")]
        public async Task<ActionResult> Enroll(EnrollIndividualTrainingRequest request)
        {
            if (request == null)
                return BadRequest();

            var command = _mapper.Map<EnrollIndividualTrainingRequest, EnrollIndividualTrainingCommand>(request);
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Confirm IndividualTraining.
        /// </summary>
        /// <param name="request">Data to confirm IndividualTraining</param>
        [HttpPost("confirm")]
        public async Task<ActionResult> Confirm(ConfirmIndividualTrainingRequest request)
        {
            if (request == null)
                return BadRequest();

            var command = _mapper.Map<ConfirmIndividualTrainingRequest, ConfirmIndividualTrainingCommand>(request);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
