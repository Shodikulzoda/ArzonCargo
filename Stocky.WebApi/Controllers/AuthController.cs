using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stocky.WebApi.Application.AuthenticationData.Commands;

namespace Stocky.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthController(IMediator mediator) : ControllerBase
{
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
    public async Task<IActionResult> Verify(VerifyLoginCommand request)
    {
        return Ok(await mediator.Send(request));
    }
}