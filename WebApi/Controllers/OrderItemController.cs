using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class OrderItemController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateOrderItem(OrderItem orderItem)
    {
        return Ok(orderItem);
    }

    [HttpGet]
    public IActionResult GetOrderItem(Guid id)
    {
        return Ok(id);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateOrderItem(OrderItem orderItem)
    {
        return Ok(orderItem);
    }

    [HttpDelete]
    public IActionResult DeleteOrderItem(Guid id)
    {
        return Ok(id);
    }
}