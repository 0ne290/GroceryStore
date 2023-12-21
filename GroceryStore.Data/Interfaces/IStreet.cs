namespace GroceryStore.Data.Interfaces;

public interface IStreet
{
    int Key { get; }

    string? Name { get; }

    int? CityKey { get; }

    ICity? CityKeyNavigation { get; }

    IEnumerable<IStore> Stores { get; }

    IEnumerable<IManufacturer> Manufacturers { get; }

    IEnumerable<IWarehouse> Warehouses { get; }
}