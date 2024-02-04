namespace GroceryStore.Core.Domain.Entities;

public sealed class Region : BaseEntity
{
    public Region() : base(new int[1]) { }

    public int Key { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }
    
    public string? Name { get; set; }

    public int? CountryKey { get; set; }

    public IEnumerable<City> Cities { get; set; } = new List<City>();

    public Country? CountryKeyNavigation { get; set; }

    public IEnumerable<Store> Stores { get; set; } = new List<Store>();

    public IEnumerable<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();

    public IEnumerable<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
