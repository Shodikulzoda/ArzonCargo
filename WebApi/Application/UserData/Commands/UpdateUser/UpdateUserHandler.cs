using MediatR;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Application.UserData.Commands.UpdateUser;

public record UpdateUserCommand : IRequest<User>
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
}

public class UpdateUserHandler(IUserRepository userRepository)
    : IRequestHandler<UpdateUserCommand, User>
{
    public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User()
        {
            Name = request.Name,
            Phone = request.Phone,
            Address = request.Address
        };
        
        await userRepository.Update(user);

        return user;
    }
}