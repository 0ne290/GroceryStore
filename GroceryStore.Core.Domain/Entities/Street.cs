namespace GroceryStore.Core.Domain.Entities;

public sealed class Street : BaseEntity
{
    public Street() : base(new int[1]) { }

    public int Key { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }

    public string? Name { get; set; }

    public int? CityKey { get; set; }

    public City? CityKeyNavigation { get; set; }

    public IEnumerable<Store> Stores { get; set; } = new List<Store>();

    public IEnumerable<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();

    public IEnumerable<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
