using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Samson.Web.Application.Queries;

namespace Samson.Web.Application.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GymPassController : ControllerBase
    {
        private readonly ILogger<GymPassController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GymPassController(ILogger<GymPassController> logger, IMapper mapper, IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("Types")]
        public async Task<ActionResult> GetGymPasses()
        {
            var query = new GymPassTypesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
