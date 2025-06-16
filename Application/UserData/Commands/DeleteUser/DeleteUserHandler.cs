using Application.Dtos.Response;
using AutoMapper;
using Domain.Models;
using Infrastructure.Repository.Interfaces;
using MediatR;

namespace Application.UserData.Commands.DeleteUser;

public class DeleteUserHandler(IUserRepository userRepository, IMapper mapper)
    : IRequestHandler<DeleteUserCommand, UserResponse>
{
    public async Task<UserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var byId = userRepository.GetById(request.Id);

        var user = mapper.Map<User>(byId);

        await userRepository.Delete(user);

        return mapper.Map<UserResponse>(user);
    }
}