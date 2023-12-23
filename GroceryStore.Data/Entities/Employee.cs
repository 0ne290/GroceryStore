namespace GroceryStore.Data.Entities;

public sealed class Employee
{
    public static Employee Empty() => new Employee()
    {
        Key = -1, FullName = "NullFullName", StoreKey = -1, PositionKey = -1, EmploymentDate = DateTime.UnixEpoch,
        PositionKeyNavigation = Position.Empty(), StoreKeyNavigation = Store.Empty()
    };
    
    public int Key { get; set; }

    public string? FullName { get; set; }

    public int? StoreKey { get; set; }

    public int? PositionKey { get; set; }

    public DateTime? EmploymentDate { get; set; }

    public Position? PositionKeyNavigation { get; set; }

    public Store? StoreKeyNavigation { get; set; }
}
