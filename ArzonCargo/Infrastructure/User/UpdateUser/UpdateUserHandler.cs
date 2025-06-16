using ArzonCargo.Dtos.Response;
using ArzonCargo.Repository.Interfaces;
using AutoMapper;
using MediatR;

namespace ArzonCargo.Infrastructure.User.UpdateUser;

public class UpdateUserHandler(IUserRepository userRepository, IMapper mapper)
    : IRequestHandler<UpdateUserCommand, UserResponse>
{
    public async Task<UserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<Models.User>(request);

        await userRepository.Update(user);

        return mapper.Map<UserResponse>(user);
    }
}