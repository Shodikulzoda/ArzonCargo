namespace Stocky.Shared.Models;

public class Pocket : BaseEntity
{
    public Guid BarCode { get; set; } = Guid.CreateVersion7();
    public double TotalAmount { get; set; }
    public double TotalWeight { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public IEnumerable<PocketItem>? PocketItems { get; set; }
}