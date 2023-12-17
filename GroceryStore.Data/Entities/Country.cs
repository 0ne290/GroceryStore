// ReSharper disable CollectionNeverUpdated.Global

using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.Entities;

public sealed class Country : ICountry
{
    public int Key { get; set; }

    public string? Name { get; set; }

    public IEnumerable<IManufacturer> Manufacturers { get; set; } = new List<IManufacturer>();

    public IEnumerable<IRegion> Regions { get; set; } = new List<IRegion>();
}
