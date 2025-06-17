using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.OrderData.Commands.CreateOrder;
using WebApi.Application.OrderItemData.Commands.CreateOrder;
using WebApi.Domain.Models;

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
    public async Task<IActionResult> CreateOrderItem(CreateOrderItemCommand orderItem)
    {
        await _mediator.Send(orderItem);
        return Ok(orderItem);
    }

    [HttpGet]
    public IActionResult GetOrderItem(int id)
    {
        return Ok(id);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _mediator.Send(id));
    }
    
    [HttpPut]
    public IActionResult UpdateOrderItem(OrderItem orderItem)
    {
        return Ok(orderItem);
    }

    [HttpDelete]
    public IActionResult DeleteOrderItem(int id)
    {
        return Ok(id);
    }
}