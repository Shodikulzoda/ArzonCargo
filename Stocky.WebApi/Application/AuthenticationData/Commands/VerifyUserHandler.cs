using MediatR;
using Microsoft.EntityFrameworkCore;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.AuthenticationData.Commands;

public record VerifyLoginCommand : IRequest<bool>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class VerifyUserHandler(IAuthRepository authRepository)
    : IRequestHandler<VerifyLoginCommand, bool>
{
    public async Task<bool> Handle(VerifyLoginCommand request, CancellationToken cancellationToken)
    {
        var auth = await authRepository.Queryable
            .FirstOrDefaultAsync(x => x.UserName == request.UserName,
                cancellationToken: cancellationToken);

        if (auth is null)
        {
            throw new Exception("User not found");
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Password, auth.PasswordHash))
        {
            return false;
        }

        return true;
    }
}