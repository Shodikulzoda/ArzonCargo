﻿namespace ReferenceClass.Models;

public class PocketItem : BaseEntity
{
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int OrderId { get; set; }
    public Order? Order { get; set; }
}