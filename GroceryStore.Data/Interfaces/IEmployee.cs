namespace GroceryStore.Data.Interfaces;

public interface IEmployee
{
    int StoreKey { get; }

    string? FullName { get; }

    int? PositionKey { get; }

    DateTime? EmploymentDate { get; }

    IPosition? PositionKeyNavigation { get; }

    IStore? StoreKeyNavigation { get; }
}