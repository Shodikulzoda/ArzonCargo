using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.PocketItemData.Commands.CreatePocketItem;
using Stocky.WebApi.Application.PocketItemData.Commands.DeletePocketItem;
using Stocky.WebApi.Application.PocketItemData.Commands.UpdatePocketItem;
using Stocky.WebApi.Application.PocketItemData.Queries.GetByPocketId;
using Stocky.WebApi.Application.PocketItemData.Queries.GetPocketItem;
using Stocky.WebApi.Application.PocketItemData.Queries.GetPocketItemByPagination;
using Stocky.WebApi.Application.PocketItemData.Queries.GetPocketItemsByPhone;

namespace Stocky.WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PocketItemController(IMediator mediator) : ControllerBase
{
    [Authorize(Roles = "Admin, Adder")]
    [HttpPost]
    public async Task<IActionResult> Add(CreatePocketItemCommand createPocketItemCommand)
    {
        return Ok(await mediator.Send(createPocketItemCommand));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PocketItem>>> GetPocketItemByPhoneNumber(
        [FromQuery] GetPocketItemByPhoneNumberQuery query)
    {
        return Ok(await mediator.Send(query));
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await mediator.Send(new GetAllPocketItemQuery()));
    }

    [Authorize(Roles = "Admin, Adder, Cashier")]
    [HttpGet]
    public async Task<ActionResult<PageData<PocketItem>>> GetPocketItemsByPocketId(
        [FromQuery] GetByPocketIdQuery getByPocketIdQuery)
    {
        return Ok(await mediator.Send(getByPocketIdQuery));
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async Task<IActionResult> Update(UpdatePocketItemCommand updatePocketItemCommand)
    {
        return Ok(await mediator.Send(updatePocketItemCommand));
    }

    [Authorize(Roles = "Admin, Cashier")]
    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] DeletePocketItemCommand deletePocketItemCommand)
    {
        return Ok(await mediator.Send(deletePocketItemCommand));
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> GetByPagination(GetPocketItemByPaginationQuery getPocketItemByPaginationQuery)
    {
        return Ok(await mediator.Send(getPocketItemByPaginationQuery));
    }
}