// ReSharper disable CollectionNeverUpdated.Global

namespace GroceryStore.Data.Models;

public sealed class Country
{
    public int Key { get; set; }

    public string? Name { get; set; }

    public ICollection<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();

    public ICollection<Region> Регионыs { get; set; } = new List<Region>();
}
