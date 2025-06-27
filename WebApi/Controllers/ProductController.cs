using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReferenceClass.Models;
using WebApi.Application.ProductData.Commands.CreateProduct;
using WebApi.Application.ProductData.Commands.DeleteProduct;
using WebApi.Application.ProductData.Commands.UpdateProduct;
using WebApi.Application.ProductData.Queries.GetAllProduct;
using WebApi.Application.ProductData.Queries.GetByBarCode;
using WebApi.Application.ProductData.Queries.GetProductById;
using WebApi.Application.ProductData.Queries.GetProductByPagination;
using WebApi.Application.ProductData.Queries.GetProductBySearch;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProductController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromQuery] CreateProductCommand createProductCommand)
    {
        return Ok(await mediator.Send(createProductCommand));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await mediator.Send(new GetAllProductQuery()));
    }

    [HttpGet]
    public async Task<IActionResult> GetProductById([FromQuery] GetProductByIdQuery getProductByIdQuery)
    {
        return Ok(await mediator.Send(getProductByIdQuery));
    }

    [HttpGet]
    public async Task<IActionResult> GetByBarCode([FromQuery] GetByBarCodeQuery query)
    {
        return Ok(await mediator.Send(query));
    }

    [HttpGet]
    public async Task<IActionResult> Search([FromQuery] GetProductBySearchQuery getProductBySearchQuery)
    {
        return Ok(await mediator.Send(getProductBySearchQuery));
    }

    [HttpGet]
    public async Task<ActionResult<PageData<Product>>> ProductPagination(
        [FromQuery] GetProductByPaginationQuery getProductByPaginationQuery)
    {
        var paginatedList = await mediator.Send(getProductByPaginationQuery);

        return Ok(paginatedList);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductCommand updateProductCommand)
    {
        return Ok(await mediator.Send(updateProductCommand));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser([FromQuery] DeleteProductCommand deleteProductCommand)
    {
        return Ok(await mediator.Send(deleteProductCommand));
    }
}