namespace Stocky.Shared.Models;

public class PocketItem : BaseEntity
{
    public string? ProductBarCode { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int PocketId { get; set; }
    public Pocket? Pocket { get; set; }
}