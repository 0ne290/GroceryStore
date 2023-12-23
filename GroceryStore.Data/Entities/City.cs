namespace GroceryStore.Data.Entities;

public sealed class City
{
    public static City Empty() => new City()
    {
        Key = -1, Name = "NullName", RegionKey = -1, RegionKeyNavigation = Region.Empty(),
        Stores = Enumerable.Empty<Store>(), Manufacturers = Enumerable.Empty<Manufacturer>(),
        Warehouses = Enumerable.Empty<Warehouse>(), Streets = Enumerable.Empty<Street>()
    };
    
    public int Key { get; set; }

    public string? Name { get; set; }

    public int? RegionKey { get; set; }

    public Region? RegionKeyNavigation { get; set; }

    public IEnumerable<Store> Stores { get; set; } = new List<Store>();

    public IEnumerable<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();

    public IEnumerable<Warehouse> Warehouses { get; set; } = new List<Warehouse>();

    public IEnumerable<Street> Streets { get; set; } = new List<Street>();
}
