using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.UserData.Commands.CreateUser;
using WebApi.Application.UserData.Commands.DeleteUser;
using WebApi.Application.UserData.Commands.UpdateUser;
using WebApi.Application.UserData.Queries.GetUser;
using WebApi.Application.UserData.Queries.GetUserById;
using WebApi.Application.UserData.Queries.UsersByPagination;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommand user)
    {
        return Ok(await mediator.Send(user));
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetAllUserQuery()));
    }

    [HttpGet]
    public async Task<IActionResult> GetUserById([FromQuery] UserByIdQuery user)
    {
        return Ok(await mediator.Send(user));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser(UpdateUserCommand user)
    {
        return Ok(await mediator.Send(user));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser(DeleteUserCommand user)
    {
        return Ok(await mediator.Send(user));
    }

    [HttpGet]
    public async Task<IActionResult> UserPagination(UsersByPaginationQuery user, CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(user, cancellationToken));
    }
}