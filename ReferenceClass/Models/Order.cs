﻿using ReferenceClass.Models.Enums;

namespace ReferenceClass.Models;

public class Order : BaseEntity
{
    public string? BarCode { get; set; }
    public double TotalAmount { get; set; }
    public double TotalWeight { get; set; }
    public Status Status { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public ICollection<PocketItem> PocketItem { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}