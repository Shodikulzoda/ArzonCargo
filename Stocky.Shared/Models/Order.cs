﻿namespace Stocky.Shared.Models;

public class Order : BaseEntity
{
    public Guid BarCode { get; set; }
    public double TotalAmount { get; set; }
    public double TotalWeight { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public IEnumerable<OrderItem>? OrderItems { get; set; }
}