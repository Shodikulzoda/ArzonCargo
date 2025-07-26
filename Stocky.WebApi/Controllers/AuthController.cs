using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stocky.WebApi.Application.AuthenticationData.Commands;
using Stocky.WebApi.Application.AuthenticationData.Queries;

namespace Stocky.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateUsersLogin(CreateLoginCommand? request)
    {
        if (request is null || string.IsNullOrWhiteSpace(request.UserName) ||
            string.IsNullOrWhiteSpace(request.Password))
        {
            return BadRequest("Invalid login data.");
        }

        return Ok(await mediator.Send(request));
    }

    [HttpPost]
    public async Task<IActionResult> Verify([FromBody] VerifyLoginCommand request)
    {
        if (string.IsNullOrWhiteSpace(request.UserName))
            return BadRequest("Invalid login datax.");

        return Ok(await mediator.Send(request));
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> GetUserById([FromBody] GetUserNameByIdQuery query)
    {
        if (query.Id <= 0)
            return BadRequest("Invalid user ID.");

        var user = await mediator.Send(query);
        if (user is null)
        {
            return NotFound("User not found.");
        }

        return Ok(user);
    }
}