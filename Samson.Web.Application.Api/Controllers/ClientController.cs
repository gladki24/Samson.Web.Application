using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Samson.Web.Application.Api.Requests.User;
using Samson.Web.Application.Api.ViewModels.User;
using Samson.Web.Application.Commands.User.Client;
using Samson.Web.Application.Infrastructure;
using Samson.Web.Application.Models.Dtos.User;
using Samson.Web.Application.Queries.User;

namespace Samson.Web.Application.Api.Controllers
{
    /// <summary>
    /// Client domain API Controller.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="mapper">Mapper to map between models</param>
        /// <param name="mediator">CQRS mediator</param>
        public ClientController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Get Client by id.
        /// </summary>
        /// <param name="id">Id of Client</param>
        /// <returns>Client</returns>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            if (id.IsNullOrEmpty())
            {
                BadRequest();
            }

            var query = _mapper.Map<string, GetClientByIdQuery>(id);
            var queryResult = await _mediator.Send(query);
            var result = _mapper.Map<ClientDto, ClientViewModel>(queryResult);

            return Ok(result);
        }

        /// <summary>
        /// Register Client.
        /// </summary>
        /// <param name="request">Data to register Client</param>
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterClientRequest request)
        {
            if (request == null)
                return BadRequest();

            var command = _mapper.Map<RegisterClientRequest, RegisterClientCommand>(request);
            var result = await _mediator.Send(command);

            return Ok(result.ToString().ToJson());
        }

        /// <summary>
        /// Update Client.
        /// </summary>
        /// <param name="request">Data to update Client</param>
        [Authorize]
        [HttpPost("update")]
        public async Task<ActionResult> Update(UpdateClientRequest request)
        {
            if (request == null)
                return BadRequest();

            var command = _mapper.Map<UpdateClientRequest, UpdateClientCommand>(request);
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Delete Client.
        /// </summary>
        /// <param name="request">Data to find and delete Client</param>
        [Authorize]
        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(DeleteUserRequest request)
        {
            if (request == null)
                return BadRequest();

            var command = _mapper.Map<DeleteUserRequest, DeleteClientCommand>(request);
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Extend Client account pass.
        /// </summary>
        [Authorize]
        [HttpPost("extendPass")]
        public async Task<ActionResult> ExtendPass(ExtendClientPassRequest request)
        {
            if (request == null)
                return BadRequest();

            var command = _mapper.Map<ExtendClientPassRequest, ExtendClientPassCommand>(request);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
