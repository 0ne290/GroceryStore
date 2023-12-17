using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.NullObjects;

public class NullCity : ICity
{
    public int Key => -1;

    public string Name => "NullCity";

    public int? RegionKey => -1;

    public IRegion RegionKeyNavigation => new NullRegion();

    public IEnumerable<IStore> Stores => Enumerable.Empty<IStore>();

    public IEnumerable<IManufacturer> Manufacturers => Enumerable.Empty<IManufacturer>();

    public IEnumerable<IWarehouse> Warehouses => Enumerable.Empty<IWarehouse>();

    public IEnumerable<IStreet> Streets => Enumerable.Empty<IStreet>();
}