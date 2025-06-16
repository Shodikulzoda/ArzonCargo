using MediatR;
using WebApi.Dtos.Response;

namespace WebApi.UserData.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<UserResponse>
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
}