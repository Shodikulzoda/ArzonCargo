using WebApi.Domain.Models.Enums;

namespace WebApi.Domain.Models;

public class Product : BaseEntity
{
    public string? BarCode { get; set; }
    public Status Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}