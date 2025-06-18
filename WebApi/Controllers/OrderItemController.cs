using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.OrderData.Commands.DeleteOrder;
using WebApi.Application.OrderData.Queries.GetAllUser;
using WebApi.Application.OrderData.Queries.OrderByPagination;
using WebApi.Application.OrderItemData.Commands.CreateOrderItem;
using WebApi.Application.OrderItemData.Commands.DeleteOrderItem;
using WebApi.Application.OrderItemData.Commands.UpdateOrderItem;
using WebApi.Application.OrderItemData.Queries.GetAllOrderItem;
using WebApi.Application.OrderItemData.Queries.GetOrderItemById;
using WebApi.Application.OrderItemData.Queries.OrderItemByPagination;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]/[action]")]

public class OrderItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderItem([FromBody] CreateOrderItemCommand order)
    {
        return Ok(await _mediator.Send(order));
    }

    [HttpGet]
    public async Task<IActionResult> GetOrderItems()
    {
        return Ok(await _mediator.Send(new GetAllOrderItemQuery()));
    }

    [HttpGet]
    public async Task<IActionResult> GetOrderItemById([FromQuery]GetOrderItemByIdQuery query)
    {
        return Ok(await _mediator.Send(query));
    }
    
    [HttpPost]
    public async Task<IActionResult> OrderPagination([FromBody] OrderItemByPaginationQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrderItem([FromBody] UpdateOrderItemCommand order)
    {
        return Ok(await _mediator.Send(order));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteOrder([FromQuery] DeleteOrderItemCommand order)
    {
        return Ok(await _mediator.Send(order));
    }
    
}