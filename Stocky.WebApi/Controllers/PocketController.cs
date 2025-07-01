using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stocky.WebApi.Application.PocketData.Commands.Createpocket;
using Stocky.WebApi.Application.PocketData.Commands.DeletePocket;
using Stocky.WebApi.Application.PocketData.Commands.Updatepocket;
using Stocky.WebApi.Application.PocketData.Queries.GetAllPocket;
using Stocky.WebApi.Application.PocketData.Queries.GetPocketById;
using Stocky.WebApi.Application.PocketData.Queries.GetPocketByPagination;
using Stocky.WebApi.Application.OrderData.Commands.CreateOrder;
using Stocky.WebApi.Application.OrderData.Commands.DeleteOrder;
using Stocky.WebApi.Application.OrderData.Commands.UpdateOrder;
using Stocky.WebApi.Application.OrderData.Queries.GetAllOrder;
using Stocky.WebApi.Application.OrderData.Queries.GetOrderById;
using Stocky.WebApi.Application.OrderData.Queries.OrderByPagination;

namespace Stocky.WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PocketController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreatePocket(CreatePocketCommand pocketCommand)
    {
        return Ok(await mediator.Send(pocketCommand));
    }

    [HttpGet]
    public async Task<IActionResult> GetPockets()
    {
        return Ok(await mediator.Send(new GetAllPocketQuery()));
    }

    [HttpGet]
    public async Task<IActionResult> GetPocketById([FromQuery] GetPocketByIdQuery pocketByIdQuery)
    {
        return Ok(await mediator.Send(pocketByIdQuery));
    }

    [HttpPost]
    public async Task<IActionResult> PocketByPagination(GetPocketByPaginationQuery pocketByPaginationQuery)
    {
        return Ok(await mediator.Send(pocketByPaginationQuery));
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePocket(UpdatePocketCommand updatePocketCommand)
    {
        return Ok(await mediator.Send(updatePocketCommand));
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePocket([FromQuery] DeletePocketCommand deletePocketCommand)
    {
        return Ok(await mediator.Send(deletePocketCommand));
    }
}