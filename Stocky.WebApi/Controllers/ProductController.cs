using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.ProductData.Commands.CreateProduct;
using Stocky.WebApi.Application.ProductData.Commands.DeleteProduct;
using Stocky.WebApi.Application.ProductData.Commands.UpdateProduct;
using Stocky.WebApi.Application.ProductData.Queries.GetAllProduct;
using Stocky.WebApi.Application.ProductData.Queries.GetByBarCode;
using Stocky.WebApi.Application.ProductData.Queries.GetProductById;
using Stocky.WebApi.Application.ProductData.Queries.GetProductByPagination;
using Stocky.WebApi.Application.ProductData.Queries.GetProductBySearch;

namespace Stocky.WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProductController(IMediator mediator) : ControllerBase
{
    [Authorize(Roles = "Adder,Admin")]
    [HttpPost]
    public async Task<IActionResult> Add([FromQuery] CreateProductCommand createProductCommand)
    {
        return Ok(await mediator.Send(createProductCommand));
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await mediator.Send(new GetAllProductQuery()));
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetProductById([FromQuery] GetProductByIdQuery getProductByIdQuery)
    {
        return Ok(await mediator.Send(getProductByIdQuery));
    }

    [Authorize(Roles = "Admin, Adder")]
    [HttpGet]
    public async Task<IActionResult> GetByBarCode([FromQuery] GetByBarCodeQuery query)
    {
        var response = await mediator.Send(query);

        if (response is null)
        {
            return NotFound("the product by this barcode is already complated");
        }

        return Ok(await mediator.Send(query));
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<ActionResult<PageData<Product>>> Search(
        [FromQuery] GetProductBySearchQuery getProductBySearchQuery)
    {
        return Ok(await mediator.Send(getProductBySearchQuery));
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<ActionResult<PageData<Product>>> ProductPagination(
        [FromQuery] GetProductByPaginationQuery getProductByPaginationQuery)
    {
        var paginatedList = await mediator.Send(getProductByPaginationQuery);

        return Ok(paginatedList);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductCommand updateProductCommand)
    {
        return Ok(await mediator.Send(updateProductCommand));
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete]
    public async Task<IActionResult> DeleteUser([FromQuery] DeleteProductCommand deleteProductCommand)
    {
        return Ok(await mediator.Send(deleteProductCommand));
    }
}