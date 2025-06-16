using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.UserData.Commands.UpdateUser;

public class UpdateUserHandler(IUserRepository userRepository, IMapper mapper)
    : IRequestHandler<UpdateUserCommand, UserResponse>
{
    public async Task<UserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request);

        await userRepository.Update(user);

        return mapper.Map<UserResponse>(user);
    }
}