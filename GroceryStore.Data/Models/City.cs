// ReSharper disable CollectionNeverUpdated.Global

namespace GroceryStore.Data.Models;

public sealed class City
{
    public int Key { get; set; }

    public string? Name { get; set; }

    public int? RegionKey { get; set; }

    public Region? RegionKeyNavigation { get; set; }

    public ICollection<Store> Stores { get; set; } = new List<Store>();

    public ICollection<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();

    public ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();

    public ICollection<Street> Streets { get; set; } = new List<Street>();
}
