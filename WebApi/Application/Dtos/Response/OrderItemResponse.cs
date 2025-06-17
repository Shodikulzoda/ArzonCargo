using WebApi.Domain.Models;

namespace WebApi.Application.Dtos.Response;

public class OrderItemResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public DateTime CreatedAt { get; set; }
    public int OrderId { get; set; }
    public Order? Order { get; set; }
}