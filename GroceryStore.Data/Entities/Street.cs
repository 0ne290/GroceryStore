// ReSharper disable CollectionNeverUpdated.Global

using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.Entities;

public sealed class Street : IStreet
{
    public int Key { get; set; }

    public string? Name { get; set; }

    public int? CityKey { get; set; }

    public ICity? CityKeyNavigation { get; set; }

    public IEnumerable<IStore> Stores { get; set; } = new List<IStore>();

    public IEnumerable<IManufacturer> Manufacturers { get; set; } = new List<IManufacturer>();

    public IEnumerable<IWarehouse> Warehouses { get; set; } = new List<IWarehouse>();
}
