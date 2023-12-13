// ReSharper disable CollectionNeverUpdated.Global

namespace GroceryStore.Data.Models;

public sealed class Street
{
    public int Key { get; set; }

    public string? Name { get; set; }

    public int? CityKey { get; set; }

    public City? CityKeyNavigation { get; set; }

    public ICollection<Store> Stores { get; set; } = new List<Store>();

    public ICollection<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();

    public ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
