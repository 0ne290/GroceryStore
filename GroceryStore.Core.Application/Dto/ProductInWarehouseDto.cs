using GroceryStore.Core.Application.Interfaces;

namespace GroceryStore.Core.Application.Dto;

public class ProductInWarehouseDto : IDto
{
    public int WarehouseKey { get; set; }

    public int ProductKey { get; set; }

    public int Quantity { get; set; }

    public DateTime DateOfManufacture { get; set; }
    
    public bool IsEmpty { get; init; }
}