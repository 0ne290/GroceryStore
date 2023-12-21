namespace GroceryStore.Data.Interfaces;

public interface IPosition
{
    int Key { get; }

    string? Name { get; }

    IEnumerable<IEmployee> StoreStaff { get; } 
}