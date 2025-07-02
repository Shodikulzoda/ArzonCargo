using MediatR;
using Microsoft.EntityFrameworkCore;
using Stocky.WebApi.Application.Interfaces;
using Stocky.WebApi.Application.Services.Interfaces;

namespace Stocky.WebApi.Application.AuthenticationData.Commands;

public record VerifyLoginCommand : IRequest<string>
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
}

public class VerifyUserHandler(IAuthRepository authRepository, IJwtService jwtService)
    : IRequestHandler<VerifyLoginCommand, string>
{
    public async Task<string> Handle(VerifyLoginCommand request, CancellationToken cancellationToken)
    {
        var user = await authRepository.Queryable.FirstOrDefaultAsync(x =>
            x.UserName == request.UserName, cancellationToken);

        if (user == null)
        {
            throw new NullReferenceException("Incorrect username or password.");
        }

        var hashPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

        if (!hashPassword)
        {
            throw new KeyNotFoundException("Incorrect username or password.");
        }

        return jwtService.GenerateToken(user);
    }
}