using WebApi.Models.Enums;

namespace WebApi.Models;

public class Product
{
    public Guid Id { get; set; }
    public string? BarCode { get; set; }
    public Status Status { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; }
}
