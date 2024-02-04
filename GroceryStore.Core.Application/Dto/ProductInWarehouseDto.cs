namespace GroceryStore.Core.Application.Dto;

public class ProductInWarehouseDto : BaseDto
{
    public ProductInWarehouseDto(bool isEmpty = true) : base(isEmpty) { }
    
    public int WarehouseKey { get; set; }

    public int ProductKey { get; set; }

    public int Quantity { get; set; }

    public DateTime DateOfManufacture { get; set; }
}