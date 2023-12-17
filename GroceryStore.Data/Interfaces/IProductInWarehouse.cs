namespace GroceryStore.Data.Interfaces;

public interface IProductInWarehouse
{
    int WarehouseKey { get; }

    int ProductKey { get; }

    int? Quantity { get; }

    DateTime? DateOfManufacture { get; }

    IWarehouse WarehouseKeyNavigation { get; }

    IProduct ProductKeyNavigation { get; }
}