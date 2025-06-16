using ArzonCargo.Dtos.Response;
using MediatR;

namespace ArzonCargo.UserData.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<UserResponse>
{
    public Guid Id { get; set; }
}