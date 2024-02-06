namespace GroceryStore.Core.Domain.Entities;

public sealed class Employee : BaseEntity
{
    public Employee() : base(new int[1]) { }
    
    public int Key { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }
    
    public string? Surname { get; set; }

    public string? Name { get; set; }
    
    public string? Patronymic { get; set; }

    public int? StoreKey { get; set; }

    public int? PositionKey { get; set; }

    public DateTime? EmploymentDate { get; set; }

    public Position? PositionKeyNavigation { get; set; }

    public Store? StoreKeyNavigation { get; set; }
}
