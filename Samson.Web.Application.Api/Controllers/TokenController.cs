using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Samson.Web.Application.Api.Requests.User;
using Samson.Web.Application.Commands.User;

namespace Samson.Web.Application.Api.Controllers
{
    /// <summary>
    /// User object API Controller. Provide CRUD operations on User model.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="mapper">Mapper to map between models</param>
        /// <param name="mediator">CQRS mediator</param>
        public TokenController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="request">Data to login User</param>
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserRequest request)
        {
            if (request == null)
                return BadRequest();

            var command = _mapper.Map<LoginUserRequest, LoginUserCommand>(request);
            var result = await _mediator.Send(command);
            return Ok(result.ToJson());
        }
    }
}
