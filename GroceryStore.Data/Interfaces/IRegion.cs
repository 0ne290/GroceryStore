namespace GroceryStore.Data.Interfaces;

public interface IRegion
{
    int Key { get; }

    string? Name { get; }

    int? CountryKey { get; }

    IEnumerable<ICity> Cities { get; }

    ICountry? CountryKeyNavigation { get; }

    IEnumerable<IStore> Stores { get; }

    IEnumerable<IManufacturer> Manufacturers { get; }

    IEnumerable<IWarehouse> Warehouses { get; }
}