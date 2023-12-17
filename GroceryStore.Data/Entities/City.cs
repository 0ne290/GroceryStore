// ReSharper disable CollectionNeverUpdated.Global

using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.Entities;

public sealed class City : ICity
{
    public int Key { get; set; }

    public string? Name { get; set; }

    public int? RegionKey { get; set; }

    public IRegion? RegionKeyNavigation { get; set; }

    public IEnumerable<IStore> Stores { get; set; } = new List<IStore>();

    public IEnumerable<IManufacturer> Manufacturers { get; set; } = new List<IManufacturer>();

    public IEnumerable<IWarehouse> Warehouses { get; set; } = new List<IWarehouse>();

    public IEnumerable<IStreet> Streets { get; set; } = new List<IStreet>();
}
