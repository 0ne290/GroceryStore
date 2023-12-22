namespace GroceryStore.Logic.Dto;

public class ProductInWarehouseDto : BaseDto
{
    public ProductInWarehouseDto(int warehouseKey, int productKey) : base(new [] { warehouseKey, productKey }) { }
    
    public int WarehouseKey { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }

    public int ProductKey { get => PrimaryKey[1]; set => PrimaryKey[1] = value; }

    public int Quantity { get; set; } = -1;

    public DateTime DateOfManufacture { get; set; } = DateTime.UnixEpoch;

    //public IWarehouse WarehouseKeyNavigation { get; set; } = null!;
//
    //public IProduct ProductKeyNavigation { get; set; } = null!;
}