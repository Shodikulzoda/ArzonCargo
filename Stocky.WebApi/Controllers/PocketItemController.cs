using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReferenceClass.Models;
using Stocky.WebApi.Application.PocketItemData.Commands.CreatePocketItem;
using Stocky.WebApi.Application.PocketItemData.Commands.DeletePocketItem;
using Stocky.WebApi.Application.PocketItemData.Commands.UpdatePocketItem;
using Stocky.WebApi.Application.PocketItemData.Queries.GetByPocketId;
using Stocky.WebApi.Application.PocketItemData.Queries.GetPocketItem;
using Stocky.WebApi.Application.PocketItemData.Queries.GetPocketItemByPagination;

namespace Stocky.WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PocketItemController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add(CreatePocketItemCommand createPocketItemCommand)
    {
        return Ok(await mediator.Send(createPocketItemCommand));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await mediator.Send(new GetAllPocketItemQuery()));
    }

    [HttpGet]
    public async Task<ActionResult<PageData<PocketItem>>> GetPocketItemsByPocketId(
        [FromQuery] GetByPocketIdQuery getByPocketIdQuery)
    {
        return Ok(await mediator.Send(getByPocketIdQuery));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdatePocketItemCommand updatePocketItemCommand)
    {
        return Ok(await mediator.Send(updatePocketItemCommand));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeletePocketItemCommand deletePocketItemCommand)
    {
        return Ok(await mediator.Send(deletePocketItemCommand));
    }

    [HttpPost]
    public async Task<IActionResult> GetByPagination(GetPocketItemByPaginationQuery getPocketItemByPaginationQuery)
    {
        return Ok(await mediator.Send(getPocketItemByPaginationQuery));
    }
}