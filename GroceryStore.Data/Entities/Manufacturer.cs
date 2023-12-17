// ReSharper disable CollectionNeverUpdated.Global

using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.Entities;

public sealed class Manufacturer : IManufacturer
{
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
    
    public ICountry? CountryKeyNavigation { get; set; }
    
    public IRegion? RegionKeyNavigation { get; set; }
    
    public ICity? CityKeyNavigation { get; set; }

    public IStreet? StreetKeyNavigation { get; set; }

    public ICollection<IProduct> Products { get; set; } = new List<IProduct>();
}
