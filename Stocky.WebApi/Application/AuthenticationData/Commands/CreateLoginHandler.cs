using MediatR;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.AuthenticationData.Commands;

public record CreateLoginCommand : IRequest<ReferenceClass.Models.AuthenticationData>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class CreateLoginHandler(IAuthRepository authRepository)
    : IRequestHandler<CreateLoginCommand, ReferenceClass.Models.AuthenticationData>
{
    public async Task<ReferenceClass.Models.AuthenticationData> Handle(CreateLoginCommand request, CancellationToken cancellationToken)
    {
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
        
        var auth = new ReferenceClass.Models.AuthenticationData
        {
            UserName = request.UserName,
            PasswordHash = hashedPassword
        };
        await authRepository.Add(auth);

        return auth;
    }
}