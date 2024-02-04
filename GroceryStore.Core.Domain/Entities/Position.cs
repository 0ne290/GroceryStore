namespace GroceryStore.Core.Domain.Entities;

public sealed class Position : BaseEntity
{
    public Position() : base(new int[1]) { }
    
    public int Key { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }

    public string? Name { get; set; }

    public IEnumerable<Employee> StoreStaff { get; set; } = new List<Employee>();
}
