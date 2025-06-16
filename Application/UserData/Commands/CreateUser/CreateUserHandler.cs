using Application.Dtos.Response;
using AutoMapper;
using Domain.Models;
using Infrastructure.Repository.Interfaces;
using MediatR;

namespace Application.UserData.Commands.CreateUser;

public class CreateUserHandler(IUserRepository userRepository, IMapper mapper)
    : IRequestHandler<CreateUserCommand, UserResponse>
{
    public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request);

        await userRepository.Add(user);

        return mapper.Map<UserResponse>(user);
    }
}