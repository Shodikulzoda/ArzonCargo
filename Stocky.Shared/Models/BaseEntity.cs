namespace Stocky.Shared.Models;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(5);
    public bool IsDeleted { get; set; }
}