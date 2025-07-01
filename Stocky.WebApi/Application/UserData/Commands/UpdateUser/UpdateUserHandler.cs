using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReferenceClass.Models;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.UserData.Commands.UpdateUser;

public record UpdateUserCommand : IRequest<User>
{
    public int Id { get; set; }
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