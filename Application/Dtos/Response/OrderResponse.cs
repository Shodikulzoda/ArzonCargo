using Domain.Models;
using Domain.Models.Enums;

namespace Application.Dtos.Response;

public class OrderResponse
{
    public int Id { get; set; }
    public string? BarCode { get; set; }
    public double TotalAmount { get; set; }
    public double TotalWeight { get; set; }
    public Status Status { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<PocketItem> PocketItem { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}