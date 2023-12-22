using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.NullObjects;

public class NullWarehouse : IWarehouse
{
    public int Key => -1;

    public DateTime? EndOfLease => DateTime.UnixEpoch;

    public string Contact => "NullContact";

    public int? RegionKey => -1;

    public int? CityKey => -1;

    public int? StreetKey => -1;

    public int? Postcode => -1;

    public int? HouseNumber => -1;

    public string HouseLetter => "NullHouseLetter";

    public IRegion RegionKeyNavigation => new NullRegion();

    public ICity CityKeyNavigation => new NullCity();

    public IStreet StreetKeyNavigation => new NullStreet();

    public IEnumerable<IProductInStore> ProductsInStores => Enumerable.Empty<IProductInStore>();

    public IEnumerable<IProductInWarehouse> ProductsInWarehouses => Enumerable.Empty<IProductInWarehouse>();
}