namespace GroceryStore.Data.Interfaces;

public interface IPosition
{
    int Key { get; }

    string? Name { get; }

    ICollection<IEmployee> StoreStaff { get; } 
}