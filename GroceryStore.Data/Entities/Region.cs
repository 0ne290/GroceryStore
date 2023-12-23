namespace GroceryStore.Data.Entities;

public sealed class Region
{
    public static Region Empty() => new Region()
    {
        Key = -1, Name = "NullName", CountryKey = -1, Cities = Enumerable.Empty<City>(),
        CountryKeyNavigation = Country.Empty(), Stores = Enumerable.Empty<Store>(),
        Manufacturers = Enumerable.Empty<Manufacturer>(), Warehouses = Enumerable.Empty<Warehouse>()
    };
    
    public int Key { get; set; }

    public string? Name { get; set; }

    public int? CountryKey { get; set; }

    public IEnumerable<City> Cities { get; set; } = new List<City>();

    public Country? CountryKeyNavigation { get; set; }

    public IEnumerable<Store> Stores { get; set; } = new List<Store>();

    public IEnumerable<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();

    public IEnumerable<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
