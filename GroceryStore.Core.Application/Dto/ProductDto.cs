using GroceryStore.Core.Application.Interfaces;

namespace GroceryStore.Core.Application.Dto;

public class ProductDto : IDto
{
    public int Key { get; set; }

    public string Name { get; set; } = string.Empty;

    public string DegreeOfProcessing { get; set; } = string.Empty;

    public int ManufacturerKey { get; set; }

    public int BestBefore { get; set; }
    
    public bool IsEmpty { get; init; }
}