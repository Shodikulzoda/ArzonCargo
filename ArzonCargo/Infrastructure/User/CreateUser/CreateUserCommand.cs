using ArzonCargo.Dtos.Response;
using ArzonCargo.Models.Enums;
using MediatR;

namespace ArzonCargo.Infrastructure.User.CreateUser;

public class CreateUserCommand : IRequest<UserResponse>
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public Role Role { get; set; }
}