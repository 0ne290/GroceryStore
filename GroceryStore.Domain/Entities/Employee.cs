using GroceryStore.Domain.Interfaces;

namespace GroceryStore.Logic.Entities;

public sealed class Employee : IEntity
{
    public int Key { get; set; }
    
    public string? Surname { get; set; }

    public string? Name { get; set; }
    
    public string? Patronymic { get; set; }

    public int? StoreKey { get; set; }

    public int? PositionKey { get; set; }

    public DateTime? EmploymentDate { get; set; }

    public Position? PositionKeyNavigation { get; set; }

    public Store? StoreKeyNavigation { get; set; }
}
