using AutoMapper;
using MediatR;
using WebApi.Dtos.Response;
using WebApi.Repository.Interfaces;

namespace WebApi.UserData.Commands.DeleteUser;

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