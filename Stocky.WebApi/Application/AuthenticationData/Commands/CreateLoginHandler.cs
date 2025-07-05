using MediatR;
using Microsoft.EntityFrameworkCore;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.AuthenticationData.Commands;

public record CreateLoginCommand : IRequest<Shared.Models.AuthenticationData>
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
}

public class CreateLoginHandler(IAuthRepository authRepository)
    : IRequestHandler<CreateLoginCommand, Shared.Models.AuthenticationData>
{
    public async Task<Shared.Models.AuthenticationData> Handle(CreateLoginCommand request,
        CancellationToken cancellationToken)
    {
        if (request.UserName is null)
        {
            throw new NullReferenceException();
        }

        var lookForUser = await authRepository.Queryable.FirstOrDefaultAsync(x =>
            x.UserName == request.UserName, cancellationToken);

        if (lookForUser != null)
        {
            throw new NullReferenceException($"the Username: {request.UserName}  already exist!");
        }

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var auth = new Shared.Models.AuthenticationData
        {
            UserName = request.UserName,
            PasswordHash = hashedPassword
        };

        await authRepository.Add(auth);
        return auth;
    }
}