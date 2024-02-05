using GroceryStore.Core.Application.Interfaces;

namespace GroceryStore.Core.Application.Dto;

public class SaleDto : IDto
{
    public int ProductKey { get; set; }

    public int CustomerKey { get; set; }

    public DateTime Date { get; set; }

    public int Quantity { get; set; }
    
    public bool IsEmpty { get; init; }
}
