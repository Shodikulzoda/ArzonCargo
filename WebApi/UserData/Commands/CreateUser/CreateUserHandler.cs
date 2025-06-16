using AutoMapper;
using MediatR;
using WebApi.Dtos.Response;
using WebApi.Repository.Interfaces;

namespace WebApi.UserData.Commands.CreateUser;

public class CreateUserHandler(IUserRepository userRepository, IMapper mapper)
    : IRequestHandler<CreateUserCommand, UserResponse>
{
    public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<Models.User>(request);

        await userRepository.Add(user);

        return mapper.Map<UserResponse>(user);
    }
}