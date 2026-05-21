using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organi.Application.Features.Sliders.Commands;
using Organi.Application.Features.Sliders.Queries;

namespace Organi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SlidersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSliders()
        {
            var values = await _mediator.Send(new GetSlidersQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSliderById(int id)
        {
            var value = await _mediator.Send(new GetSliderByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderCommand command)
        {
            await _mediator.Send(command);
            return Ok("Slider created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveSlider(int id)
        {
            await _mediator.Send(new RemoveSliderCommand(id));
            return Ok("Slider deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSlider(UpdateSliderCommand command)
        {
            await _mediator.Send(command);
            return Ok("Slider updated");
        }
    }
}
