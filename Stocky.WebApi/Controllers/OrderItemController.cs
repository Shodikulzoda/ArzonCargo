using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.OrderItemData.Commands.CreateOrderItem;
using Stocky.WebApi.Application.OrderItemData.Commands.DeleteOrderItem;
using Stocky.WebApi.Application.OrderItemData.Commands.UpdateOrderItem;
using Stocky.WebApi.Application.OrderItemData.Queries.GetAllOrderItem;
using Stocky.WebApi.Application.OrderItemData.Queries.GetByOrderId;
using Stocky.WebApi.Application.OrderItemData.Queries.GetOrderItemById;
using Stocky.WebApi.Application.OrderItemData.Queries.GetOrderItemsByPhone;
using Stocky.WebApi.Application.OrderItemData.Queries.OrderItemByPagination;

namespace Stocky.WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class OrderItemController(IMediator mediator) : ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateOrderItem([FromBody] CreateOrderItemCommand order)
    {
        return Ok(await mediator.Send(order));
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PocketItem>>> GetOrderItemByPhoneNumber([FromQuery] GetOrderItemByPhoneNumberQuery query)
    {
        return Ok(await mediator.Send(query));
    }
    
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetOrderItems()
    {
        return Ok(await mediator.Send(new GetAllOrderItemQuery()));
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetOrderItemById([FromQuery] GetOrderItemByIdQuery query)
    {
        return Ok(await mediator.Send(query));
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<ActionResult<PageData<OrderItem>>> GetOrderItemsByOrderId(
        [FromQuery] GetByOrderIdQuery getByOrderIdQuery)
    {
        return Ok(await mediator.Send(getByOrderIdQuery));
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> OrderPagination([FromBody] OrderItemByPaginationQuery query)
    {
        return Ok(await mediator.Send(query));
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async Task<IActionResult> UpdateOrderItem([FromBody] UpdateOrderItemCommand order)
    {
        return Ok(await mediator.Send(order));
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete]
    public async Task<IActionResult> DeleteOrder([FromQuery] DeleteOrderItemCommand order)
    {
        return Ok(await mediator.Send(order));
    }
}