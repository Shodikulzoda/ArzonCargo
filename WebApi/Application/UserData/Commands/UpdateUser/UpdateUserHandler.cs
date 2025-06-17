using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Application.UserData.Commands.UpdateUser;

public record UpdateUserCommand(int Id) : IRequest<User>
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
}

public class UpdateUserHandler(IUserRepository userRepository)
    : IRequestHandler<UpdateUserCommand, User?>
{
    public async Task<User?> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetById(request.Id);
        if (user is null)
            return null;

        user.Name = request.Name;
        user.Phone = request.Phone;
        user.Address = request.Address;

        await userRepository.Update(user);

        return user;
    }
}