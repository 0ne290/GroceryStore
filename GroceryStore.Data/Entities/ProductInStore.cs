using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.Entities;

public sealed class ProductInStore : IProductInStore
{
    public int StoreKey { get; set; }

    public int ProductKey { get; set; }

    public int? Quantity { get; set; }

    public int? WarehouseKey { get; set; }

    public IStore StoreKeyNavigation { get; set; } = null!;

    public IProduct ProductKeyNavigation { get; set; } = null!;

    public IWarehouse? WarehouseKeyNavigation { get; set; }
}
