namespace GroceryStore.Data.Entities;

public sealed class Manufacturer
{
    public static Manufacturer Empty() => new Manufacturer()
    {
        Key = -1, Name = "NullName", Contact = "NullContact", CountryKey = -1, RegionKey = -1, CityKey = -1,
        StreetKey = -1, Postcode = -1, HouseNumber = -1, HouseLetter = "NullHouseLetter",
        CountryKeyNavigation = Country.Empty(), RegionKeyNavigation = Region.Empty(), CityKeyNavigation = City.Empty(),
        StreetKeyNavigation = Street.Empty(), Products = Enumerable.Empty<Product>()
    };
    
    public int Key { get; set; }

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
