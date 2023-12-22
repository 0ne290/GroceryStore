﻿// ReSharper disable CollectionNeverUpdated.Global

using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.Entities;

public sealed class Product : IProduct
{
    public int Key { get; set; }

    public string? Name { get; set; }

    public string? DegreeOfProcessing { get; set; }

    public int? ManufacturerKey { get; set; }

    public int? BestBefore { get; set; }

    public IManufacturer? ManufacturerKeyNavigation { get; set; }

    public IEnumerable<ISale> Sales { get; set; } = new List<ISale>();

    public IEnumerable<IProductInStore> ProductsInStores { get; set; } = new List<IProductInStore>();

    public IEnumerable<IProductInWarehouse> ProductsInWarehouses { get; set; } = new List<IProductInWarehouse>();
}
