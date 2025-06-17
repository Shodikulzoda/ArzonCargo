using Domain.Models;
using Domain.Models.Enums;

namespace Application.Dtos.Response;

public class ProductResponse
{
    public int Id { get; set; }
    public string? BarCode { get; set; }
    public Status Status { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; }
}