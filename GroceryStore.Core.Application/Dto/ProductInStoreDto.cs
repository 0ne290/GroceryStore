namespace GroceryStore.Core.Application.Dto;

public class ProductInStoreDto : BaseDto
{
    public ProductInStoreDto(bool isEmpty = true) : base(isEmpty) { }
    
    public int StoreKey { get; set; }

    public int ProductKey { get; set; }

    public int Quantity { get; set; }

    public int WarehouseKey { get; set; }
}