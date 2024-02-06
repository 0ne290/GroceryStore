namespace GroceryStore.Core.Domain.Entities;

public sealed class ProductInStore : BaseEntity
{
    public ProductInStore() : base(new int[2]) { }
    
    public int StoreKey { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }

    public int ProductKey { get => PrimaryKey[1]; set => PrimaryKey[1] = value; }

    public int? Quantity { get; set; }

    public int? WarehouseKey { get; set; }

    public Store StoreKeyNavigation { get; set; } = null!;

    public Product ProductKeyNavigation { get; set; } = null!;

    public Warehouse? WarehouseKeyNavigation { get; set; }
}
