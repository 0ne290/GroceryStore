namespace GroceryStore.Data.Interfaces;

public interface IProductInStore
{
    int StoreKey { get; }

    int ProductKey { get; }

    int? Quantity { get; }

    int? WarehouseKey { get; }

    IStore? StoreKeyNavigation { get; }

    IProduct? ProductKeyNavigation { get; }

    IWarehouse? WarehouseKeyNavigation { get; }
}