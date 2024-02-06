using GroceryStore.Core.Application.Interfaces;

namespace GroceryStore.Core.Application.Dto;

public class PositionDto : IDto
{
    public int Key { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public bool IsEmpty { get; init; }
}
