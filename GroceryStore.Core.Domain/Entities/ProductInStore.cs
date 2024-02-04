using GroceryStore.Core.Domain.Interfaces;

namespace GroceryStore.Core.Domain.Entities;

public sealed class ProductInStore : IEntity
{
    public int StoreKey { get; set; }

    public int ProductKey { get; set; }

    public int? Quantity { get; set; }

    public int? WarehouseKey { get; set; }

    public Store StoreKeyNavigation { get; set; } = null!;

    public Product ProductKeyNavigation { get; set; } = null!;

    public Warehouse? WarehouseKeyNavigation { get; set; }
}
