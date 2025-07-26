using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.OrderData.Commands.CreateOrder;
using Stocky.WebApi.Application.OrderData.Commands.DeleteOrder;
using Stocky.WebApi.Application.OrderData.Commands.UpdateOrder;
using Stocky.WebApi.Application.OrderData.Queries.GetAllOrder;
using Stocky.WebApi.Application.OrderData.Queries.GetOrderById;
using Stocky.WebApi.Application.OrderData.Queries.GetOrdersByUserId;
using Stocky.WebApi.Application.OrderData.Queries.OrderByPagination;

namespace Stocky.WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class OrderController(IMediator mediator) : ControllerBase
{
    [Authorize(Roles = "Admin,Cashier")]
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand order)
    {
        return Ok(await mediator.Send(order));
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        return Ok(await mediator.Send(new GetAllOrderQuery()));
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetOrderById([FromQuery] GetOrderByIdQuery query)
    {
        return Ok(await mediator.Send(query));
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<ActionResult<PageData<Order>>> GetOrdersByUserId(
        [FromQuery] GetOrdersByUserIdQuery getOrdersByUserIdQuery)
    {
        return Ok(await mediator.Send(getOrdersByUserIdQuery));
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> OrderByPagination(OrderByPaginationQuery query)
    {
        return Ok(await mediator.Send(query));
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async Task<IActionResult> UpdateOrder(UpdateOrderCommand order)
    {
        return Ok(await mediator.Send(order));
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete]
    public async Task<IActionResult> DeleteOrder([FromQuery] DeleteOrderCommand order)
    {
        return Ok(await mediator.Send(order));
    }
}