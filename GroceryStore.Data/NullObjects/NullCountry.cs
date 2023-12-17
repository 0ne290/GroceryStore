using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.NullObjects;

public class NullCountry : ICountry
{
    public int Key => -1;

    public string Name => "NullCountry";

    public IEnumerable<IManufacturer> Manufacturers => Enumerable.Empty<IManufacturer>();

    public IEnumerable<IRegion> Regions => Enumerable.Empty<IRegion>();
}