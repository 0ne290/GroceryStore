namespace GroceryStore.Data.Interfaces;

public interface ICity
{
    int Key { get; }

    string? Name { get; }

    int? RegionKey { get; }

    IRegion? RegionKeyNavigation { get; }

    IEnumerable<IStore> Stores { get; }

    IEnumerable<IManufacturer> Manufacturers { get; }

    IEnumerable<IWarehouse> Warehouses { get; }

    IEnumerable<IStreet> Streets { get; }
}