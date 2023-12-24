using GroceryStore.Data.Interfaces;

namespace GroceryStore.Data.Entities;

public sealed class ProductInWarehouse : IEntity
{
    public int WarehouseKey { get; set; }

    public int ProductKey { get; set; }

    public int? Quantity { get; set; }

    public DateTime? DateOfManufacture { get; set; }

    public Warehouse WarehouseKeyNavigation { get; set; } = null!;

    public Product ProductKeyNavigation { get; set; } = null!;
}
