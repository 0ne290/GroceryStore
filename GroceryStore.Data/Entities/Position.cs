﻿using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.Entities;

public sealed class Position : IEntity
{
    public int Key { get; set; }

    public string? Name { get; set; }

    public IEnumerable<Employee> StoreStaff { get; set; } = new List<Employee>();
}
