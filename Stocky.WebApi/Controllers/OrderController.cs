using MediatR;
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
    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderCommand order)
    {
        return Ok(await mediator.Send(order));
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        return Ok(await mediator.Send(new GetAllOrderQuery()));
    }

    [HttpGet]
    public async Task<IActionResult> GetOrderById([FromQuery] GetOrderByIdQuery query)
    {
        return Ok(await mediator.Send(query));
    }

    [HttpGet]
    public async Task<ActionResult<PageData<Order>>> GetOrdersByUserId(
        [FromQuery] GetOrdersByUserIdQuery getOrdersByUserIdQuery)
    {
        return Ok(await mediator.Send(getOrdersByUserIdQuery));
    }

    [HttpPost]
    public async Task<IActionResult> OrderByPagination(OrderByPaginationQuery query)
    {
        return Ok(await mediator.Send(query));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrder(UpdateOrderCommand order)
    {
        return Ok(await mediator.Send(order));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteOrder([FromQuery] DeleteOrderCommand order)
    {
        return Ok(await mediator.Send(order));
    }
}