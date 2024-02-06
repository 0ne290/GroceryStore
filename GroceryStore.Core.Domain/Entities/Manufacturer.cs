namespace GroceryStore.Core.Domain.Entities;

public sealed class Manufacturer : BaseEntity
{
    public Manufacturer() : base(new int[1]) { }
    
    public int Key { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }

    public string? Name { get; set; }

    public string? Contact { get; set; }

    public int? CountryKey { get; set; }

    public int? RegionKey { get; set; }

    public int? CityKey { get; set; }

    public int? StreetKey { get; set; }

    public int? Postcode { get; set; }

    public int? HouseNumber { get; set; }

    public string? HouseLetter { get; set; }
    
    public Country? CountryKeyNavigation { get; set; }
    
    public Region? RegionKeyNavigation { get; set; }
    
    public City? CityKeyNavigation { get; set; }

    public Street? StreetKeyNavigation { get; set; }

    public IEnumerable<Product> Products { get; set; } = new List<Product>();
}
