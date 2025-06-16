using Domain.Models.Enums;

namespace Domain.Models;

public class User
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public Role Role { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<Order> Orders { get; set; }
}