using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Organi.Application.Features.Dashboard.Queries;

namespace Organi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetStats")]
        public async Task<IActionResult> GetStats()
        {
            var result = await _mediator.Send(new GetDashboardStatsQuery());
            return Ok(result);
        }

        [HttpGet("GetCategoryDistribution")]
        public async Task<IActionResult> GetCategoryDistribution()
        {
            var result = await _mediator.Send(new GetCategoryDistributionQuery());
            return Ok(result);
        }
    }
}
