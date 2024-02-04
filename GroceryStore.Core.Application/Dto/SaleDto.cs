namespace GroceryStore.Core.Application.Dto;

public class SaleDto : BaseDto
{
    public SaleDto(bool isEmpty = true) : base(isEmpty) { }
    
    public int ProductKey { get; set; }

    public int CustomerKey { get; set; }

    public DateTime Date { get; set; }

    public int Quantity { get; set; }
}
