using MediatR;
using ReferenceClass.Models;
using ReferenceClass.Models.Enums;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.UserData.Commands.CreateUser;

public record CreateUserCommand : IRequest<User>
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public Role Role { get; set; }
}

public class CreateUserHandler(IUserRepository userRepository)
    : IRequestHandler<CreateUserCommand, User>
{
    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User()
        {
            Name = request.Name,
            Phone = request.Phone,
            Address = request.Address,
        };
        await userRepository.Add(user);

        return user;
    }
}