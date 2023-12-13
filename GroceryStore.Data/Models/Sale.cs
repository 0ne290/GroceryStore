namespace GroceryStore.Data.Models;

public sealed class Sale
{
    public int ProductKey { get; set; }

    public int CustomerKey { get; set; }

    public DateTime Date { get; set; }

    public int? Quantity { get; set; }

    public RegularCustomer CustomerKeyNavigation { get; set; } = null!;

    public Product ProductKeyNavigation { get; set; } = null!;
}
