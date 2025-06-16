using ArzonCargo.Dtos.Response;
using ArzonCargo.Repository.Interfaces;
using AutoMapper;
using MediatR;

namespace ArzonCargo.UserData.Commands.DeleteUser;

public class DeleteUserHandler(IUserRepository userRepository, IMapper mapper)
    : IRequestHandler<DeleteUserCommand, UserResponse>
{
    public async Task<UserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var byId = userRepository.GetById(request.Id);

        var user = mapper.Map<Models.User>(byId);

        await userRepository.Delete(user);

        return mapper.Map<UserResponse>(user);
    }
}