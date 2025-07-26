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

[ApiController]
[Route("[controller]/[action]")]
public class PocketController(IMediator mediator) : ControllerBase
{
    [Authorize(Roles = "Admin, Adder")]
    [HttpPost]
    public async Task<IActionResult> CreatePocket(CreatePocketCommand pocketCommand)
    {
        return Ok(await mediator.Send(pocketCommand));
    }
    
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetPockets()
    {
        return Ok(await mediator.Send(new GetAllPocketQuery()));
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetPocketById([FromQuery] GetPocketByIdQuery pocketByIdQuery)
    {
        return Ok(await mediator.Send(pocketByIdQuery));
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<ActionResult<PageData<Pocket>>> GetPocketsByUserId(
        [FromQuery] GetPocketsByUserIdQuery getPocketsByUserIdQuery)
    {
        return Ok(await mediator.Send(getPocketsByUserIdQuery));
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetPocketBySearch([FromQuery] SearchPocketQuery query)
    {
        return Ok(await mediator.Send(query));
    }

    [Authorize(Roles = "Admin, Adder")]
    [HttpGet]
    public async Task<ActionResult<PageData<Pocket>>> PocketPagination(
        [FromQuery] GetPocketByPaginationQuery getPocketByPaginationQuery)
    {
        return Ok(await mediator.Send(getPocketByPaginationQuery));
    }
    
    [Authorize(Roles = "Admin, Adder")]
    [HttpPut]
    public async Task<IActionResult> UpdatePocket(UpdatePocketCommand updatePocketCommand)
    {
        return Ok(await mediator.Send(updatePocketCommand));
    }
    
    [Authorize(Roles = "Admin, Adder")]
    [HttpDelete]
    public async Task<IActionResult> DeletePocket([FromQuery] DeletePocketCommand deletePocketCommand)
    {
        return Ok(await mediator.Send(deletePocketCommand));
    }
}