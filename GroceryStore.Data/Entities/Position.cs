namespace GroceryStore.Data.Entities;

public sealed class Position
{
    public static Position Empty() => new Position()
    {
        Key = -1, Name = "NullName", StoreStaff = Enumerable.Empty<Employee>()
    };
    
    public int Key { get; set; }

    public string? Name { get; set; }

    public IEnumerable<Employee> StoreStaff { get; set; } = new List<Employee>();
}
