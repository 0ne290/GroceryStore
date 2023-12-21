namespace GroceryStore.Data.Interfaces;

public interface IEmployee
{
    int Key { get; }

    string? FullName { get; }
    
    int? StoreKey { get; }
    
    int? PositionKey { get; }

    DateTime? EmploymentDate { get; }

    IPosition? PositionKeyNavigation { get; }

    IStore? StoreKeyNavigation { get; }
}