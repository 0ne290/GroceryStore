// ReSharper disable CollectionNeverUpdated.Global

using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.Entities;

public sealed class Street : IStreet
{
    public int Key { get; set; }

    public string? Name { get; set; }

    public int? CityKey { get; set; }

    public ICity? CityKeyNavigation { get; set; }

    public ICollection<IStore> Stores { get; set; } = new List<IStore>();

    public ICollection<IManufacturer> Manufacturers { get; set; } = new List<IManufacturer>();

    public ICollection<IWarehouse> Warehouses { get; set; } = new List<IWarehouse>();
}
