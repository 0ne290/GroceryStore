using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.Entities;

public sealed class Employee : IEmployee
{
    public int StoreKey { get; set; }

    public string? FullName { get; set; }

    public int? PositionKey { get; set; }

    public DateTime? EmploymentDate { get; set; }

    public IPosition? PositionKeyNavigation { get; set; }

    public IStore? StoreKeyNavigation { get; set; }
}
