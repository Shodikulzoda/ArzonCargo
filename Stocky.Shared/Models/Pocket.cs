using ReferenceClass.Models.Enums;

namespace ReferenceClass.Models;

public class Pocket : BaseEntity
{
    public string? BarCode { get; set; }
    public double TotalAmount { get; set; }
    public double TotalWeight { get; set; }
    public Status Status { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public IEnumerable<PocketItem> PocketItems { get; set; }
}