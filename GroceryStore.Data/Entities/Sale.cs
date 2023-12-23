namespace GroceryStore.Data.Entities;

public sealed class Sale
{
    public static Sale Empty() => new Sale()
    {
        ProductKey = -1, CustomerKey = -1, Date = DateTime.UnixEpoch, Quantity = -1,
        CustomerKeyNavigation = RegularCustomer.Empty(), ProductKeyNavigation = Product.Empty()
    };
    
    public int ProductKey { get; set; }

    public int CustomerKey { get; set; }

    public DateTime Date { get; set; }

    public int? Quantity { get; set; }

    public RegularCustomer CustomerKeyNavigation { get; set; } = null!;

    public Product ProductKeyNavigation { get; set; } = null!;
}
