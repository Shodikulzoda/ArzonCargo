using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.OrderData.Commands.CreateOrder;
using WebApi.Application.OrderData.Commands.DeleteOrder;
using WebApi.Application.OrderData.Commands.UpdateOrder;
using WebApi.Application.OrderData.Queries.GetAllOrder;
using WebApi.Application.OrderData.Queries.GetOrderById;
using WebApi.Application.OrderData.Queries.OrderByPagination;
using WebApi.Application.PocketData.Commands.Createpocket;
using WebApi.Application.PocketData.Commands.DeletePocket;
using WebApi.Application.PocketData.Commands.Updatepocket;
using WebApi.Application.PocketData.Queries.GetAllPocket;
using WebApi.Application.PocketData.Queries.GetPocketById;
using WebApi.Application.PocketData.Queries.GetPocketByPagination;

namespace WebApi.Controllers;

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