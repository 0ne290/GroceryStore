namespace GroceryStore.Data.Entities;

public sealed class ProductInStore
{
    public static ProductInStore Empty() => new ProductInStore()
    {
        StoreKey = -1, ProductKey = -1, Quantity = -1, WarehouseKey = -1, StoreKeyNavigation = Store.Empty(),
        ProductKeyNavigation = Product.Empty(), WarehouseKeyNavigation = Warehouse.Empty()
    };
    
    public int StoreKey { get; set; }

    public int ProductKey { get; set; }

    public int? Quantity { get; set; }

    public int? WarehouseKey { get; set; }

    public Store StoreKeyNavigation { get; set; } = null!;

    public Product ProductKeyNavigation { get; set; } = null!;

    public Warehouse? WarehouseKeyNavigation { get; set; }
}
