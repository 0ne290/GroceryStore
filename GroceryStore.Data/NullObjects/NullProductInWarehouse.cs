using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.NullObjects;

public class NullProductInWarehouse : IProductInWarehouse
{
    public int WarehouseKey => -1;

    public int ProductKey => -1;

    public int? Quantity => -1;

    public DateTime? DateOfManufacture => DateTime.UnixEpoch;

    public IWarehouse WarehouseKeyNavigation => new NullWarehouse();

    public IProduct ProductKeyNavigation => new NullProduct();
}