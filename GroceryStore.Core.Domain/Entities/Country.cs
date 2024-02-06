namespace GroceryStore.Core.Domain.Entities;

public sealed class Country : BaseEntity
{
    public Country() : base(new int[1]) { }
    
    public int Key { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }

    public string? Name { get; set; }

    public IEnumerable<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();

    public IEnumerable<Region> Regions { get; set; } = new List<Region>();
}
