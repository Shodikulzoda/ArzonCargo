using Domain.Models.Enums;

namespace Domain.Models;

public class Order
{
    public Guid Id { get; set; }
    public string? BarCode { get; set; }
    public double TotalAmount { get; set; }
    public double TotalWeight { get; set; }
    public Status Status { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }

    public User User { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}
