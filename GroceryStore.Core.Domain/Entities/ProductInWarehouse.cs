namespace GroceryStore.Core.Domain.Entities;

public sealed class ProductInWarehouse : BaseEntity
{
    public ProductInWarehouse() : base(new int[2]) { }
    
    public int WarehouseKey { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }

    public int ProductKey { get => PrimaryKey[1]; set => PrimaryKey[1] = value; }

    public int? Quantity { get; set; }

    public DateTime? DateOfManufacture { get; set; }

    public Warehouse WarehouseKeyNavigation { get; set; } = null!;

    public Product ProductKeyNavigation { get; set; } = null!;
}
