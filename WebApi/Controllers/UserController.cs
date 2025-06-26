using System.Diagnostics.CodeAnalysis;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReferenceClass.Models;
using WebApi.Application.UserData.Commands.CreateUser;
using WebApi.Application.UserData.Commands.DeleteUser;
using WebApi.Application.UserData.Commands.UpdateUser;
using WebApi.Application.UserData.Queries.GetUser;
using WebApi.Application.UserData.Queries.GetUserById;
using WebApi.Application.UserData.Queries.Search;
using WebApi.Application.UserData.Queries.UsersByPagination;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommand? user)
    {
        if (string.IsNullOrEmpty(user.Name))
        {
            return BadRequest("User cannot be null");
        }

        return Ok(await mediator.Send(user));
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(await mediator.Send(new GetAllUserQuery()));
    }

    [HttpGet]
    public async Task<IActionResult> GetUserById([FromQuery] UserByIdQuery user)
    {
        return Ok(await mediator.Send(user));
    }

    [HttpGet]
    public async Task<ActionResult<UserDto>> UserPagination(
        [FromQuery] UsersByPaginationQuery getProductByPaginationQuery)
    {
        var userDto = new UserDto();
        var paginatedList = await mediator.Send(getProductByPaginationQuery);
        userDto.Users = paginatedList.Items;
        userDto.TotalCount = paginatedList.TotalCount;

        return Ok(userDto);
    }

    [HttpGet]
    public async Task<IActionResult> Search([FromQuery] SearchQuery query)
    {
        return Ok(await mediator.Send(query));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser(UpdateUserCommand user)
    {
        return Ok(await mediator.Send(user));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser([FromQuery] DeleteUserCommand user)
    {
        return Ok(await mediator.Send(user));
    }
}