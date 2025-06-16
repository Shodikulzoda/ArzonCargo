using Application.Dtos.Response;
using MediatR;

namespace Application.UserData.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<UserResponse>
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
}