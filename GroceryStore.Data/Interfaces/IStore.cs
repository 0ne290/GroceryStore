using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.Interfaces;

public interface IStore
{
    int Key { get; }

    DateTime? EndOfLease { get; }

    string? Contact { get; }

    int? RegionKey { get; }

    int? CityKey { get; }

    int? StreetKey { get; }

    int? Postcode { get; }

    int? HouseNumber { get; }

    string? HouseLetter { get; }
    
    IRegion? RegionKeyNavigation { get; }
    
    ICity? CityKeyNavigation { get; }

    IStreet? StreetKeyNavigation { get; }

    IEnumerable<IEmployee> Staff { get; }

    IEnumerable<IProductInStore> Products { get; }
}