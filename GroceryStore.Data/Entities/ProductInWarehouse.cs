using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.Entities;

public sealed class ProductInWarehouse : IProductInWarehouse
{
    public int WarehouseKey { get; set; }

    public int ProductKey { get; set; }

    public int? Quantity { get; set; }

    public DateTime? DateOfManufacture { get; set; }

    public IWarehouse WarehouseKeyNavigation { get; set; } = null!;

    public IProduct ProductKeyNavigation { get; set; } = null!;
}
