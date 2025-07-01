using ReferenceClass.Models.Enums;

namespace ReferenceClass.Models;

public class User : BaseEntity
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public Role Role { get; set; }
    public IEnumerable<Order> Orders { get; set; }
    public IEnumerable<Pocket> Pockets { get; set; }
}