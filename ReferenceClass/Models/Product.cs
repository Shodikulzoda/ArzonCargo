using ReferenceClass.Models.Enums;

namespace ReferenceClass.Models;

public class Product : BaseEntity
{
    public string? BarCode { get; set; }
    public Status Status { get; set; } 
    public ICollection<OrderItem> OrderItems { get; set; }
    public ICollection<PocketItem> PocketItems { get; set; }
}