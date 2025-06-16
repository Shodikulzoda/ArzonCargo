using Application.Dtos.Response;
using Domain.Models.Enums;
using MediatR;

namespace Application.UserData.Commands.CreateUser;

public class CreateUserCommand : IRequest<UserResponse>
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public Role Role { get; set; }
}