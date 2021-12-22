using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Samson.Web.Application.Api.Requests.User;
using Samson.Web.Application.Api.ViewModels.User;
using Samson.Web.Application.Commands.User;
using Samson.Web.Application.Commands.User.PersonalTrainer;
using Samson.Web.Application.Infrastructure;
using Samson.Web.Application.Models.Dtos.User;
using Samson.Web.Application.Queries.User;

namespace Samson.Web.Application.Api.Controllers
{
    /// <summary>
    /// PersonalTrainer domain API controller.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class PersonalTrainerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="mapper">Mapper to map between models</param>
        /// <param name="mediator">CQRS mediator</param>
        public PersonalTrainerController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Get PersonalTrainer by id.
        /// </summary>
        /// <param name="id">Id of PersonalTrainer</param>
        /// <returns>PersonalTrainer</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            if (id.IsNullOrEmpty())
            {
                BadRequest();
            }

            var query = _mapper.Map<string, GetPersonalTrainerByIdQuery>(id);
            var queryResult = await _mediator.Send(query);
            var result = _mapper.Map<PersonalTrainerDto, PersonalTrainerViewModel>(queryResult);

            return Ok(result);
        }

        /// <summary>
        /// Create PersonalTrainer account.
        /// </summary>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<ActionResult> Create(CreatePersonalTrainerRequest request)
        {
            if (request == null)
                return BadRequest();

            var command = _mapper.Map<CreatePersonalTrainerRequest, CreatePersonalTrainerCommand>(request);
            var result = await _mediator.Send(command);
            return Ok(result.ToString().ToJson());
        }

        /// <summary>
        /// Update PersonalTrainer account.
        /// </summary>
        /// <param name="request">Data to update PersonalTrainer account</param>
        [HttpPost("update")]
        public async Task<ActionResult> Update(UpdatePersonalTrainerRequest request)
        {
            if (request == null)
                return BadRequest();

            var command = _mapper.Map<UpdatePersonalTrainerRequest, UpdatePersonalTrainerCommand>(request);
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Delete PersonalTrainer account.
        /// </summary>
        /// <param name="request"></param>
        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(DeleteUserRequest request)
        {
            if (request == null)
                return BadRequest();

            var command = _mapper.Map<DeleteUserRequest, DeletePersonalTrainerCommand>(request);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
