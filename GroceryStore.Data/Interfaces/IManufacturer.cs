namespace GroceryStore.Data.Interfaces;

public interface IManufacturer
{
    int Key { get; }

    string? Name { get; }

    string? Contact { get; }

    int? CountryKey { get; }

    int? RegionKey { get; }

    int? CityKey { get; }

    int? StreetKey { get; }

    int? Postcode { get; }

    int? HouseNumber { get; }

    string? HouseLetter { get; }
    
    ICountry? CountryKeyNavigation { get; }
    
    IRegion? RegionKeyNavigation { get; }
    
    ICity? CityKeyNavigation { get; }

    IStreet? StreetKeyNavigation { get; }

    IEnumerable<IProduct> Products { get; }
}