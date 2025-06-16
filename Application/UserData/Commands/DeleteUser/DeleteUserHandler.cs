using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.UserData.Commands.DeleteUser;

public record DeleteUserCommand : IRequest<UserResponse>
{
    public int Id { get; set; }
}

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