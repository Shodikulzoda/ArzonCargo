using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.PocketItemData.Commands.CreatePocketItem;
using WebApi.Application.PocketItemData.Commands.DeletePocketItem;
using WebApi.Application.PocketItemData.Commands.UpdatePocketItem;
using WebApi.Application.PocketItemData.Queries.GetPocketItem;
using WebApi.Application.PocketItemData.Queries.GetPocketItemByPagination;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PocketController(IMediator mediator) : ControllerBase
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