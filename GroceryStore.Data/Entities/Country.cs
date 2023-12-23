namespace GroceryStore.Data.Entities;

public sealed class Country
{
    public static Country Empty() => new Country()
    {
        Key = -1, Name = "NullName", Manufacturers = Enumerable.Empty<Manufacturer>(),
        Regions = Enumerable.Empty<Region>()
    };
    
    public int Key { get; set; }

    public string? Name { get; set; }

    public IEnumerable<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();

    public IEnumerable<Region> Regions { get; set; } = new List<Region>();
}
