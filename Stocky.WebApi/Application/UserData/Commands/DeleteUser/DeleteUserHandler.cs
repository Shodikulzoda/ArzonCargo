using MediatR;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.UserData.Commands.DeleteUser;

public record DeleteUserCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class DeleteUserHandler(IUserRepository userRepository)
    : IRequestHandler<DeleteUserCommand, bool>
{
    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return await userRepository.Delete(request.Id);
    }
}