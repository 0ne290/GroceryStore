namespace GroceryStore.Data.Models;

public sealed class Employee
{
    public int StoreKey { get; set; }

    public string? FullName { get; set; }

    public int? PositionKey { get; set; }

    public DateTime? EmploymentDate { get; set; }

    public Position? PositionKeyNavigation { get; set; }

    public Store? StoreKeyNavigation { get; set; }
}
