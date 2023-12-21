using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.NullObjects;

public class NullStreet : IStreet
{
    public int Key => -1;

    public string Name => "NullName";

    public int? CityKey => -1;

    public ICity CityKeyNavigation => new NullCity();

    public IEnumerable<IStore> Stores => Enumerable.Empty<IStore>();

    public IEnumerable<IManufacturer> Manufacturers => Enumerable.Empty<IManufacturer>();

    public IEnumerable<IWarehouse> Warehouses => Enumerable.Empty<IWarehouse>();
}