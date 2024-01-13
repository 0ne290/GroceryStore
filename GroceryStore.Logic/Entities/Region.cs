using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Logic.Entities;

public sealed class Region : IEntity
{
    public int Key { get; set; }

    public string? Name { get; set; }

    public int? CountryKey { get; set; }

    public IEnumerable<City> Cities { get; set; } = new List<City>();

    public Country? CountryKeyNavigation { get; set; }

    public IEnumerable<Store> Stores { get; set; } = new List<Store>();

    public IEnumerable<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();

    public IEnumerable<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
