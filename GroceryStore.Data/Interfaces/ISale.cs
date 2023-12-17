namespace GroceryStore.Data.Interfaces;

public interface ISale
{
    int ProductKey { get; }

    int CustomerKey { get; }

    DateTime Date { get; }

    int? Quantity { get; }

    IRegularCustomer CustomerKeyNavigation { get; }

    IProduct ProductKeyNavigation { get; }
}