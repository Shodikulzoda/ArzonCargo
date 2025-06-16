using ArzonCargo.Dtos.Response;
using MediatR;

namespace ArzonCargo.Infrastructure.User.DeleteUser;

public class DeleteUserCommand : IRequest<UserResponse>
{
    public Guid Id { get; set; }
}