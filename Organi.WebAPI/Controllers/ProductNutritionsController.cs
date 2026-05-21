using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Organi.Application.Features.ProductNutritions.Commands;
using Organi.Application.Features.ProductNutritions.Queries;

namespace Organi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductNutritionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductNutritionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductNutritions()
        {
            var values = await _mediator.Send(new GetAllProductNutritionsQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductNutritionByProductId(int id)
        {
            var value = await _mediator.Send(new GetProductNutritionByProductIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductNutrition(CreateProductNutritionCommand command)
        {
            await _mediator.Send(command);
            return Ok("Nutrition created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProductNutrition(int id)
        {
            await _mediator.Send(new RemoveProductNutritionCommand(id));
            return Ok("Nutrition deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductNutrition(UpdateProductNutritionCommand command)
        {
            await _mediator.Send(command);
            return Ok("Nutrition updated");
        }
    }
}
