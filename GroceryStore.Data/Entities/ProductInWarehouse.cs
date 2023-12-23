namespace GroceryStore.Data.Entities;

public sealed class ProductInWarehouse
{
    public static ProductInWarehouse Empty() => new ProductInWarehouse()
    {
        WarehouseKey = -1, ProductKey = -1, Quantity = -1, DateOfManufacture = DateTime.UnixEpoch,
        WarehouseKeyNavigation = Warehouse.Empty(), ProductKeyNavigation = Product.Empty()
    };
    
    public int WarehouseKey { get; set; }

    public int ProductKey { get; set; }

    public int? Quantity { get; set; }

    public DateTime? DateOfManufacture { get; set; }

    public Warehouse WarehouseKeyNavigation { get; set; } = null!;

    public Product ProductKeyNavigation { get; set; } = null!;
}
