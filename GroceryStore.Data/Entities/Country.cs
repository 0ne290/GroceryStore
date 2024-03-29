﻿using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.Entities;

public sealed class Country : IEntity
{
    public int Key { get; set; }

    public string? Name { get; set; }

    public IEnumerable<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();

    public IEnumerable<Region> Regions { get; set; } = new List<Region>();
}
