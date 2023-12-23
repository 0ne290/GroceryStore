namespace GroceryStore.Data.Entities;

public sealed class Store
{
    public static Store Empty() => new Store()
    {
        Key = -1, EndOfLease = DateTime.UnixEpoch, Contact = "NullContact", RegionKey = -1, CityKey = -1,
        StreetKey = -1, Postcode = -1, HouseNumber = -1, HouseLetter = "NullHouseLetter",
        RegionKeyNavigation = Region.Empty(), CityKeyNavigation = City.Empty(), StreetKeyNavigation = Street.Empty(),
        Staff = Enumerable.Empty<Employee>(), Products = Enumerable.Empty<ProductInStore>()
    };
    
    public int Key { get; set; }

    public DateTime? EndOfLease { get; set; }

    public string? Contact { get; set; }

    public int? RegionKey { get; set; }

    public int? CityKey { get; set; }

    public int? StreetKey { get; set; }

    public int? Postcode { get; set; }

    public int? HouseNumber { get; set; }

    public string? HouseLetter { get; set; }
    
    public Region? RegionKeyNavigation { get; set; }
    
    public City? CityKeyNavigation { get; set; }

    public Street? StreetKeyNavigation { get; set; }

    public IEnumerable<Employee> Staff { get; set; } = new List<Employee>();

    public IEnumerable<ProductInStore> Products { get; set; } = new List<ProductInStore>();
}
