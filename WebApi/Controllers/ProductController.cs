using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ProductData.Commands.CreateProduct;
using WebApi.Application.ProductData.Commands.DeleteProduct;
using WebApi.Application.ProductData.Commands.UpdateProduct;
using WebApi.Application.ProductData.Queries.GetAllProduct;
using WebApi.Application.ProductData.Queries.GetProductByPagination;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProductController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add(CreateProductCommand createProductCommand)
    {
        return Ok(await mediator.Send(createProductCommand));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await mediator.Send(new GetAllProductQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> UserPagination(GetProductByPaginationQuery getProductByPaginationQuery)
    {
        return Ok(await mediator.Send(getProductByPaginationQuery));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser(UpdateProductCommand updateProductCommand)
    {
        return Ok(await mediator.Send(updateProductCommand));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser([FromQuery] DeleteProductCommand deleteProductCommand)
    {
        return Ok(await mediator.Send(deleteProductCommand));
    }
}