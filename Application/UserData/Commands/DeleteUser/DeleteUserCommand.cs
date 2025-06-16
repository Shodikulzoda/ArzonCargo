using Application.Dtos.Response;
using MediatR;

namespace Application.UserData.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<UserResponse>
{
    public Guid Id { get; set; }
}