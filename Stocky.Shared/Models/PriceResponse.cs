namespace Stocky.Shared.Models;

public class PriceResponse
{
    public decimal pricePerKg { get; set; }
    public int id { get; set; }
    public DateTime createdAt { get; set; }
    public bool isDeleted { get; set; }
}