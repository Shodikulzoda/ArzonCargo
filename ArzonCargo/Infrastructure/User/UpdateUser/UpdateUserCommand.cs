using ArzonCargo.Dtos.Response;
using MediatR;

namespace ArzonCargo.Infrastructure.User.UpdateUser;

public class UpdateUserCommand : IRequest<UserResponse>
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
}