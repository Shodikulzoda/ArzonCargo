﻿using ArzonCargo.Models;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Role { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<Order> Orders { get; set; }
}