using MediatR;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;
using WebApi.Domain.Models.Enums;

namespace WebApi.Application.UserData.Commands.CreateUser;

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
            Role = request.Role
        };

        await userRepository.Add(user);

        return user;
    }
}