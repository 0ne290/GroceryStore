namespace GroceryStore.Core.Domain.Entities;

public sealed class City : BaseEntity
{
    public City(int key) : base(new [] { key }) { }
    
    public City() : base(new [] { -1 }) { }
    
    public int Key { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }

    public string? Name { get; set; }

    public int? RegionKey { get; set; }

    public Region? RegionKeyNavigation { get; set; }

    public IEnumerable<Store> Stores { get; set; } = new List<Store>();

    public IEnumerable<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();

    public IEnumerable<Warehouse> Warehouses { get; set; } = new List<Warehouse>();

    public IEnumerable<Street> Streets { get; set; } = new List<Street>();
}
