using Application.Features.Categories.Commands;
using Application.Features.Categories.Models;
using Application.Features.Categories.Queries;
using Application.Features.Products.Models;
using Application.Features.Products.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CategoriesController : ApiControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById([FromRoute] Guid id)
        {
            var result = await Mediator.Send(new GetCategoryByIdQuery() { Id = id });
            return Ok(result);
        }

        [HttpGet("{id}/products")]
        public async Task<ActionResult<List<ProductDto>>> GetProductListBy([FromRoute] Guid id)
        {
            var result = await Mediator.Send(new GetProductListByCategoryIdQuery() { CategoryId = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<CategoryDto>> GetList()
        {
            var result = await Mediator.Send(new GetCategoryListQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create([FromBody] CreateCategoryCommand command)
        {
            var result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] EditCategoryCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await Mediator.Send(new DeleteCategoryCommand() { Id = id });
            return NoContent();
        }
    }
}
