﻿// ReSharper disable CollectionNeverUpdated.Global

using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.Entities;

public sealed class RegularCustomer : IRegularCustomer
{
    public int Key { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public ICollection<ISale> Purchases { get; set; } = new List<ISale>();
}