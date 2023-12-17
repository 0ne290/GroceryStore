using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.Entities;

public sealed class Sale : ISale
{
    public int ProductKey { get; set; }

    public int CustomerKey { get; set; }

    public DateTime Date { get; set; }

    public int? Quantity { get; set; }

    public IRegularCustomer CustomerKeyNavigation { get; set; } = null!;

    public IProduct ProductKeyNavigation { get; set; } = null!;
}
