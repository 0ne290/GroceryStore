namespace GroceryStore.Data.Interfaces;

public interface IRegularCustomer
{
    int Key { get; }

    string? Name { get; }

    string? Address { get; }

    string? PhoneNumber { get; }

    IEnumerable<ISale> Purchases { get; }
}