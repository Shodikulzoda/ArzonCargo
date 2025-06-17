using WebApi.Domain.Models;
using WebApi.Domain.Models.Enums;

namespace WebApi.Application.Dtos.Response;

public class UserResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public Role Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Order> Orders { get; set; }
}