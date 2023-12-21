using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.NullObjects;

public class NullManufacturer : IManufacturer
{
    public int Key => -1;

    public string Name => "NullName";

    public string Contact => "NullContact";

    public int? CountryKey => -1;

    public int? RegionKey => -1;

    public int? CityKey => -1;

    public int? StreetKey => -1;

    public int? Postcode => -1;

    public int? HouseNumber => -1;

    public string HouseLetter => "NullHouseLetter";

    public ICountry CountryKeyNavigation => new NullCountry();

    public IRegion RegionKeyNavigation => new NullRegion();

    public ICity CityKeyNavigation => new NullCity();

    public IStreet StreetKeyNavigation => new NullStreet();

    public IEnumerable<IProduct> Products => Enumerable.Empty<IProduct>();
}