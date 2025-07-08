using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.PocketData.Commands.Createpocket;
using Stocky.WebApi.Application.PocketData.Commands.DeletePocket;
using Stocky.WebApi.Application.PocketData.Commands.Updatepocket;
using Stocky.WebApi.Application.PocketData.Queries.GetAllPocket;
using Stocky.WebApi.Application.PocketData.Queries.GetPocketById;
using Stocky.WebApi.Application.PocketData.Queries.GetPocketByPagination;
using Stocky.WebApi.Application.PocketData.Queries.GetPocketBySearch;
using Stocky.WebApi.Application.PocketData.Queries.GetPocketByUserId;

namespace Stocky.WebApi.Controllers;

[Authorize(Roles = "Admin")]
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

    [HttpGet]
    public async Task<ActionResult<PageData<Pocket>>> GetPocketsByUserId(
        [FromQuery] GetPocketsByUserIdQuery getPocketsByUserIdQuery)
    {
        return Ok(await mediator.Send(getPocketsByUserIdQuery));
    }

    [HttpGet]
    public async Task<IActionResult> GetPocketBySearch([FromQuery] SearchPocketQuery query)
    {
        return Ok(await mediator.Send(query));
    }

    [HttpGet]
    public async Task<ActionResult<PageData<Pocket>>> PocketPagination(
        [FromQuery] GetPocketByPaginationQuery getPocketByPaginationQuery)
    {
        return Ok(await mediator.Send(getPocketByPaginationQuery));
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