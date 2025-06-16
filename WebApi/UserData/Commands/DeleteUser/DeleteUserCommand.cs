using MediatR;
using WebApi.Dtos.Response;

namespace WebApi.UserData.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<UserResponse>
{
    public Guid Id { get; set; }
}