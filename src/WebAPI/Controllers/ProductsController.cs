using Application.Features.Products.Commands;
using Application.Features.Products.Models;
using Application.Features.Products.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class ProductsController : ApiControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById([FromRoute] Guid id)
        {
            var result = await Mediator.Send(new GetProductByIdQuery() { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ProductDto>> GetList()
        {
            var result = await Mediator.Send(new GetProductListQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create([FromBody] CreateProductCommand command)
        {
            var result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] EditProductCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await Mediator.Send(new DeleteProductCommand() { Id = id });
            return NoContent();
        }
    }
}
