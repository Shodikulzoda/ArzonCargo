using Application.Dtos.Response;
using AutoMapper;
using Domain.Models;
using Infrastructure.Repository.Interfaces;
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