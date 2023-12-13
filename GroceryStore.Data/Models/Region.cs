// ReSharper disable CollectionNeverUpdated.Global

namespace GroceryStore.Data.Models;

public sealed class Region
{
    public int Key { get; set; }

    public string? Name { get; set; }

    public int? CountryKey { get; set; }

    public ICollection<City> Cities { get; set; } = new List<City>();

    public Country? CountryKeyNavigation { get; set; }

    public ICollection<Store> Stores { get; set; } = new List<Store>();

    public ICollection<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();

    public ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
