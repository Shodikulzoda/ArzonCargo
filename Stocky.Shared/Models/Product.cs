using ReferenceClass.Models.Enums;

namespace ReferenceClass.Models;

public class Product : BaseEntity
{
        public string? BarCode { get; set; }
        public Status Status { get; set; } 
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public IEnumerable<PocketItem> PocketItems { get; set; }
}