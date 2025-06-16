using MediatR;
using WebApi.Dtos.Response;
using WebApi.Models.Enums;

namespace WebApi.UserData.Commands.CreateUser;

public class CreateUserCommand : IRequest<UserResponse>
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public Role Role { get; set; }
}