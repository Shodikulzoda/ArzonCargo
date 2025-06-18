using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.OrderData.Commands.CreateOrder;
using WebApi.Application.OrderData.Commands.DeleteOrder;
using WebApi.Application.OrderData.Commands.UpdateOrder;
using WebApi.Application.OrderData.Queries.GetAllUser;
using WebApi.Application.OrderData.Queries.GetOrderById;
using WebApi.Application.OrderData.Queries.OrderByPagination;
using WebApi.Domain.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderCommand order)
    {
        return Ok(await _mediator.Send(order));
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        return Ok(await _mediator.Send(new GetAllOrderQuery()));
    }

    [HttpGet]
    public async Task<IActionResult> GetOrderById([FromQuery] GetOrderByIdQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<IActionResult> OrderByPagination(OrderByPaginationQuery query,CancellationToken cancellation)
    {
        return Ok(await _mediator.Send(query,cancellation));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrder(UpdateOrderCommand order)
    {
        return Ok(await _mediator.Send(order));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteOrder([FromQuery]DeleteOrderCommand order)
    {
        return Ok(await _mediator.Send(order));
    }
}