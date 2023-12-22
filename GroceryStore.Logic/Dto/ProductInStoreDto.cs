namespace GroceryStore.Logic.Dto;

public class ProductInStoreDto : BaseDto
{
    public ProductInStoreDto(int storeKey, int productKey) : base(new[] { storeKey, productKey }) { }
    
    public int StoreKey { get => PrimaryKey[0]; set => PrimaryKey[0] = value; }

    public int ProductKey { get => PrimaryKey[1]; set => PrimaryKey[1] = value; }

    public int Quantity { get; set; } = -1;

    public int WarehouseKey { get; set; } = -1;

    //public IStore? StoreKeyNavigation { get; set; }
//
    //public IProduct? ProductKeyNavigation { get; set; }
//
    //public IWarehouse? WarehouseKeyNavigation { get; set; }
}