using ArzonCargo.Dtos.Response;
using ArzonCargo.Models;
using ArzonCargo.Models.Enums;
using MediatR;

namespace ArzonCargo.Infrastructure.User.GetUser;

public class GetAllUserQuery : IRequest<IEnumerable<UserResponse>>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public Role Role { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<Order> Orders { get; set; }
}