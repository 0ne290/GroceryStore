using GroceryStore.Core.Application.Interfaces;

namespace GroceryStore.Core.Application.Dto;

public class ProductInStoreDto : IDto
{
    public int StoreKey { get; set; }

    public int ProductKey { get; set; }

    public int Quantity { get; set; }

    public int WarehouseKey { get; set; }
    
    public bool IsEmpty { get; init; }
}