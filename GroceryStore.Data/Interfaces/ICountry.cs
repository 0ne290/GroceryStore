namespace GroceryStore.Data.Interfaces;

public interface ICountry
{
    int Key { get; }

    string? Name { get; }

    IEnumerable<IManufacturer> Manufacturers { get; }

    IEnumerable<IRegion> Regions { get; }
}