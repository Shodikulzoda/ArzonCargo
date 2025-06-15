using ArzonCargo.Models.Enums;

namespace ArzonCargo.Models;

public class Product
{
    public Guid Id { get; set; }
    public string BarCode { get; set; }
    public int Status { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; }
}
