using ArzonCargo.Models;
using ArzonCargo.Models.Enums;

namespace ArzonCargo.Dtos.Response;

public class UserResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public Role Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Order> Orders { get; set; }
}