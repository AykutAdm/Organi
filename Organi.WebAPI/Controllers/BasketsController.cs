using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Organi.Application.Features.Baskets.Commands;
using Organi.Application.Features.Baskets.Queries;

namespace Organi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBaskets()
        {
            var values = await _mediator.Send(new GetAllBasketsQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasket(CreateBasketCommand command)
        {
            await _mediator.Send(command);
            return Ok("Product added to basket");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBasket(int id)
        {
            await _mediator.Send(new RemoveBasketCommand(id));
            return Ok("Product removed from basket");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBasket(UpdateBasketCommand command)
        {
            await _mediator.Send(command);
            return Ok("Basket updated");
        }
    }
}
