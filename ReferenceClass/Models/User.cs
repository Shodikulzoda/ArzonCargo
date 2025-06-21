using ReferenceClass.Models.Enums;

namespace ReferenceClass.Models;

public class User : BaseEntity
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public Role Role { get; set; }
    public ICollection<Order> Orders { get; set; }
}