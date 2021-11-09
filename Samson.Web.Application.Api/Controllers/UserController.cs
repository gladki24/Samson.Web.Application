using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Samson.Web.Application.Api.Requests.User;
using Samson.Web.Application.Api.ViewModels.User;
using Samson.Web.Application.Commands.User;
using Samson.Web.Application.Infrastructure;
using Samson.Web.Application.Models.Dtos.User;
using Samson.Web.Application.Queries.User;

namespace Samson.Web.Application.Api.Controllers
{
    /// <summary>
    /// User object API Controller. Provide CRUD operations on User model.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="mapper">Mapper to map between models</param>
        /// <param name="mediator">CQRS mediator</param>
        public UserController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Get User by id.
        /// </summary>
        /// <param name="id">Id of User</param>
        /// <returns>User</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            if (id.IsNullOrEmpty())
            {
                BadRequest();
            }

            var query = _mapper.Map<string, GetUserByIdQuery>(id);
            var queryResult = await _mediator.Send(query);
            var result = _mapper.Map<UserDto, UserViewModel>(queryResult);
            return Ok(result);
        }

        /// <summary>
        /// Create new User.
        /// </summary>
        /// <param name="request">Data to create User</param>
        [HttpPost("create")]
        public async Task<ActionResult> Create(CreateUserRequest request)
        {
            if (request == null)
            {
                BadRequest();
            }

            var command = _mapper.Map<CreateUserRequest, CreateUserCommand>(request);
            var result = await _mediator.Send(command);
            return Ok(result.ToJson());
        }

        /// <summary>
        /// Update User.
        /// </summary>
        /// <param name="request">Data to update User</param>
        [HttpPost("update")]
        public async Task<ActionResult> Update(UpdateUserRequest request)
        {
            if (request == null)
            {
                BadRequest();
            }

            var command = _mapper.Map<UpdateUserRequest, UpdateUserCommand>(request);
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Delete User.
        /// </summary>
        /// <param name="request">Data to find, validate and delete User</param>
        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(DeleteUserRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var command = _mapper.Map<DeleteUserRequest, DeleteUserCommand>(request);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginUserRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var command = _mapper.Map<LoginUserRequest, LoginUserCommand>(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
