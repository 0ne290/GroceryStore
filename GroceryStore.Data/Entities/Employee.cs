using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Data.Entities;

public sealed class Employee : IEntity
{
    public int Key { get; set; }

    public string? FullName { get; set; }

    public int? StoreKey { get; set; }

    public int? PositionKey { get; set; }

    public DateTime? EmploymentDate { get; set; }

    public Position? PositionKeyNavigation { get; set; }

    public Store? StoreKeyNavigation { get; set; }
}
