using ArzonCargo.Dtos.Response;
using ArzonCargo.Repository.Interfaces;
using AutoMapper;
using MediatR;

namespace ArzonCargo.Infrastructure.User.CreateUser;

public class CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    : IRequestHandler<CreateUserCommand, UserResponse>
{
    public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<Models.User>(request);

        await userRepository.Add(user);

        return mapper.Map<UserResponse>(user);
    }
}