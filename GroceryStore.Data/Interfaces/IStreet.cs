namespace GroceryStore.Data.Interfaces;

public interface IStreet
{
    int Key { get; }

    string? Name { get; }

    int? CityKey { get; }

    ICity? CityKeyNavigation { get; }

    ICollection<IStore> Stores { get; }

    ICollection<IManufacturer> Manufacturers { get; }

    ICollection<IWarehouse> Warehouses { get; }
}