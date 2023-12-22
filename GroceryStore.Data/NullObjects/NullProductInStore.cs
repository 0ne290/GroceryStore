using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.NullObjects;

public class NullProductInStore : IProductInStore
{
    public int StoreKey => -1;

    public int ProductKey => -1;

    public int? Quantity => -1;

    public int? WarehouseKey => -1;

    public IStore StoreKeyNavigation => new NullStore();

    public IProduct ProductKeyNavigation => new NullProduct();

    public IWarehouse WarehouseKeyNavigation => new NullWarehouse();
}