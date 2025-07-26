using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stocky.WebApi.Application.Services;

namespace Stocky.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class PriceListController(IMediator mediator) : ControllerBase
{
    [Authorize(Roles = "Admin,Cashier")]
    [HttpPost]
    public async Task<IActionResult> PriceChanger(PriceChangerCommand? newPrice)
    {
        if (newPrice is null || newPrice.newPrice <= 0)
        {
            return BadRequest("Invalid price.");
        }

        try
        {
            var result = await mediator.Send(newPrice);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [Authorize(Roles = "Admin,Cashier")]
    [HttpGet]
    public async Task<IActionResult> GetPrice()
    {
        var priceList = await mediator.Send(new PriceChangerGetPriceQuery());
        return Ok(priceList);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAllPrices()
    {
        var prices = await mediator.Send(new PriceChangerGetAllQuery());
        if (!prices.Any())
        {
            return NotFound("No prices found.");
        }

        return Ok(prices);
    }
}