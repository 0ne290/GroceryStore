using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.Entities;

public sealed class City : IEntity
{
    public int Key { get; set; }

    public string? Name { get; set; }

    public int? RegionKey { get; set; }

    public Region? RegionKeyNavigation { get; set; }

    public IEnumerable<Store> Stores { get; set; } = new List<Store>();

    public IEnumerable<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();

    public IEnumerable<Warehouse> Warehouses { get; set; } = new List<Warehouse>();

    public IEnumerable<Street> Streets { get; set; } = new List<Street>();
}
