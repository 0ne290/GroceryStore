using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.NullObjects;

public class NullRegion : IRegion
{
    public int Key => -1;

    public string Name => "NullName";

    public int? CountryKey => -1;

    public IEnumerable<ICity> Cities => Enumerable.Empty<ICity>();

    public ICountry CountryKeyNavigation => new NullCountry();

    public IEnumerable<IStore> Stores => Enumerable.Empty<IStore>();

    public IEnumerable<IManufacturer> Manufacturers => Enumerable.Empty<IManufacturer>();

    public IEnumerable<IWarehouse> Warehouses => Enumerable.Empty<IWarehouse>();
}