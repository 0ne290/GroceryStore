namespace GroceryStore.Data.Entities;

public sealed class Street
{
    public static Street Empty() => new Street()
    { 
        Key = -1, Name = "NullName", CityKey = -1, CityKeyNavigation = City.Empty(), Stores = Enumerable.Empty<Store>(),
        Manufacturers = Enumerable.Empty<Manufacturer>(), Warehouses = Enumerable.Empty<Warehouse>()
    };
    
    public int Key { get; set; }

    public string? Name { get; set; }

    public int? CityKey { get; set; }

    public City? CityKeyNavigation { get; set; }

    public IEnumerable<Store> Stores { get; set; } = new List<Store>();

    public IEnumerable<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();

    public IEnumerable<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
