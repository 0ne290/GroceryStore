namespace GroceryStore.Core.Domain.Entities;

public sealed class RegularCustomer : BaseEntity
{
    public RegularCustomer() : base(new int[1]) { }

    public int Key { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public IEnumerable<Sale> Purchases { get; set; } = new List<Sale>();
}
